using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpSupport;
using VisionControl;
using VisionSupport;
//using

namespace Server.Ver1
{
    public partial class FrmServer : Form
    {
        /// <summary>
        /// Nest class
        /// </summary>
        class IPData
        {
            public int Id { get; set; }
            public string IP { get; set; }
        }

        class ProcessingArgs : EventArgs
        {
            public Socket TcpSocket { get; set; }
            public byte[] Data { get; set; }
            public long Takttime { get; set; }
            public ProcessingArgs(Socket tcpSocket, byte[] data, long takttime)
            {
                TcpSocket = tcpSocket;
                Data = data;
                Takttime = takttime;
            }
        }

        #region Form's variable
        private string OldtbxIPAddress { get; set; } = "";
        public TcpServer Server { get; set; }
        public List<string> AccessableIPs { get; set; }
        public bool EnableIpFilter { get; set; } = true;
        #endregion
        public FrmServer()
        {
            InitializeComponent();
        }
        #region Form's Event
        public event EventHandler Processed;
        public void OnProcessed(Socket client, byte[] data, long takttime)
        {
            Processed?.Invoke(this,new ProcessingArgs(client, data, takttime));
        }
        private void FrmServer_Load(object sender, EventArgs e)
        {
            this.IPAddressTable.Initial(this.IPAddressTable.Name);
            this.IPAddressTable.TableChanged += IPAddressTable_TableChanged;
            //Load ToolBlock
            List<ToolBlockSetting.ToolBlockInfo> toolinfo = ToolBlockSetting.GetToolBlockInfos();
            Dictionary<string, CogToolBlock> toolblocks = new Dictionary<string, CogToolBlock>(); ;
            foreach(ToolBlockSetting.ToolBlockInfo info in toolinfo)
            {
                CogToolBlock tool;
                try
                {
                   tool = CogSerializer.LoadObjectFromFile(info.ToolBlockPath) as CogToolBlock;
                   toolblocks.Add(info.ToolBlockID, tool);
                }
                catch
                {
                    toolinfo.Remove(info);
                }
            }
            this.TeachingToolBlockControl.SetupControl(toolinfo, toolblocks);
            //Load IPAddress
            string ip = "";
            using (LiteDatabase db = new LiteDatabase(Path.Combine(Resource.DBProvider.DBFolderPath, "ProgramSource.db")))
            {
                var col = db.GetCollection<IPData>("IpAddress");
                IPData[] iplist = col.FindAll().ToArray();
                if (iplist != null)
                {
                    if (iplist.Length > 0)
                    {
                        ip = iplist[0].IP;
                    }
                }
            }
            tbxIPAddress.Text = ip;
            //TCP
            // Initial Server
            Server = new TcpServer();
            Server.Opened += Server_Opened;
            Server.Closed += Server_Closed;
            Server.Accepted += Server_Accepted;
            Server.Received += Server_Received;
            Server.Sended += Server_Sended;
            Server.ReceivedTimeouted += Server_ReceivedTimeouted;
            Server.SendTimeouted += Server_SendTimeouted;
        }

        private void IPAddressTable_TableChanged(object sender, EventArgs e)
        {
            lock (this.AccessableIPs)
            {
                this.AccessableIPs = sender  as List<string>;
            }
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            if (Server.ServerStatus == TcpServer.Status.Online)
            {
                Server.Close();
            }
            else
            {
                Task _openserver = Server.Open(GetServerEP());
            }        
        }
        private void tbxIPAddress_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxIPAddress.Text)) throw new ArgumentException(tbxIPAddress.Name);
                string ipraw = tbxIPAddress.Text;
                string[] ip_array = ipraw.Split(':');
                if (ip_array.Length != 2) throw new ArgumentException(tbxIPAddress.Name);
                string ip = ip_array[0];
                string sport = ip_array[1];
                int port = 0;
                if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(sport)) throw new ArgumentException(tbxIPAddress.Name);
                if (!int.TryParse(sport, out port)) throw new ArgumentException(tbxIPAddress.Name);
                using (LiteDatabase db = new LiteDatabase(Path.Combine(Resource.DBProvider.DBFolderPath, "ProgramSource.db")))
                {
                    var col = db.GetCollection<IPData>("IpAddress");
                    col.DeleteAll();
                    col.Insert(new IPData { IP = ipraw });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("IP is invalid", "Warning");
                //MessageBox.Show("IP is invalid");
                tbxIPAddress.Text = OldtbxIPAddress;
            }
        }
        private void tbxIPAddress_Enter(object sender, EventArgs e)
        {
            OldtbxIPAddress = tbxIPAddress.Text;
        }
        #endregion
        #region TCP
        private IPEndPoint GetServerEP()
        {
            if (string.IsNullOrEmpty(tbxIPAddress.Text)) throw new ArgumentException(tbxIPAddress.Name);
            string ipraw = tbxIPAddress.Text;
            string[] ip_array = ipraw.Split(':');
            if (ip_array.Length != 2) throw new ArgumentException(tbxIPAddress.Name);
            string ip = ip_array[0];
            string sport = ip_array[1];
            int port = 0;
            if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(sport)) throw new ArgumentException(tbxIPAddress.Name);
            if (!int.TryParse(sport, out port)) throw new ArgumentException(tbxIPAddress.Name);
            IPEndPoint serverendpoint = new IPEndPoint(IPAddress.Parse(ip), port);
            return serverendpoint;
        }
        #endregion
        #region Server's Event
        private void Server_Opened(object sender, EventArgs e)
        {
            lock (lbServerStatus)
            {
                btnOpenServer.BackgroundImage = Properties.Resources.DisconnectIcon.ToBitmap();
                lbServerStatus.Text = "ONLINE!";
            }
        }
        private void Server_Closed(object sender, EventArgs e)
        {
            lock (lbServerStatus)
            {
                btnOpenServer.BackgroundImage = Properties.Resources.ConnectIcon.ToBitmap();
                lbServerStatus.Text = "OFFLINE!";
            }
        }
        private void Server_Accepted(object sender, EventArgs e)
        {
            Thread _thread = new Thread(() =>
            {
                Socket client = sender as Socket;
                string clientip = ((IPEndPoint)client.RemoteEndPoint).Address.ToString();
                if (this.AccessableIPs != null)
                {
                    if (this.EnableIpFilter)
                    {
                        if (!this.AccessableIPs.Contains(clientip)) return;
                    }
                }
                Server.Receive(client);
            });
            _thread.Start();
        }
        private void Server_Received(object sender, EventArgs e)
        {
            TcpBase.TcpReceiveArgs receiveargs = (TcpBase.TcpReceiveArgs)e;
            long receivetakttime = receiveargs.TaktTime;
            byte[] receivedata = receiveargs.Data;
            Socket client = receiveargs.TcpSocket;

        }
        private void Server_ReceivedTimeouted(object sender, EventArgs e)
        {
        }
        private void Server_Sended(object sender, EventArgs e)
        {
            long sendtakttime = ((TcpBase.TcpSendArgs)e).TaktTime;
        }
        private void Server_SendTimeouted(object sender, EventArgs e)
        {
        }
        #endregion
        #region Vision
        public byte[] Processing(Socket client,byte[] receivedData)
        {
            int count = 0;
            bool complete = false;
            byte[] data = null;
            try
            {
                Thread _process = new Thread(() =>
                {
                    try
                    {
                        CogToolBlock tool;
                        CogToolBlockTerminalCollection inputterminaltool;
                        TerminalCollection sendterminalcollection = new TerminalCollection();
                        long deserialtakttime = 0;


                        DataCarrier datacarrier = Serialize.Serialize.DeserializeDataCarrerier(receivedData, out deserialtakttime);
                        string toolblockid = datacarrier.ToolID;
                        TerminalCollection input = datacarrier.TerminalCollection;
                        if (!this.TeachingToolBlockControl.ToolBlocks.ContainsKey(toolblockid))
                        {
                            throw new ArgumentOutOfRangeException(toolblockid);
                        }
                        lock (this.TeachingToolBlockControl.ToolBlocks)
                        {
                            tool = CogSerializer.DeepCopyObject(this.TeachingToolBlockControl.ToolBlocks[toolblockid]) as CogToolBlock;
                            inputterminaltool = tool.Inputs;
                        }
                        foreach (KeyValuePair<string, Terminal> ter in input)
                        {
                            Terminal _terminal = ter.Value;
                            if (_terminal.Type == typeof(Bitmap))
                            {
                                ICogImage image = new CogImage8Grey(_terminal.Value as Bitmap);
                                tool.Inputs[_terminal.Name].Value = image;
                            }
                            else
                            {
                                tool.Inputs[_terminal.Name].Value = _terminal.Value;
                            }
                            tool.Run();
                            foreach(CogToolBlockTerminal outterminal in tool.Outputs)
                            {
                                if(outterminal.ValueType == typeof(ICogImage))
                                {
                                    Bitmap bitimage = (outterminal.Value as ICogImage).ToBitmap();
                                    sendterminalcollection.Add(new Terminal(outterminal.Name,bitimage,typeof(Bitmap)));
                                }
                                else
                                {
                                    sendterminalcollection.Add(new Terminal(outterminal.Name, outterminal.Value, outterminal.ValueType));
                                }
                            }
                            long serialtakttime = 0;
                            byte[] senddata = Serialize.Serialize.SerializeTerminalCollection(sendterminalcollection, out serialtakttime);
                            complete = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
                _process.IsBackground = true;
                _process.Start();
                while (count < 300 && !complete)
                {
                    Thread.Sleep(10);
                }
                if (!complete)
                {
                    if (_process.IsAlive)
                    {
                        _process.Abort();
                        throw new TimeoutException("Processing timeout!");
                    }
                }
                else if(data != null)
                {
                    throw new Exception("Data is NULL!");
                }

                Server.Send(client, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }
        #endregion

    }
}
