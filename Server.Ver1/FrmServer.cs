 using LiteDB;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpSupport;

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

        #region Form's variable
        private string OldtbxIPAddress { get; set; } = "";
        public TcpServer Server { get; set; }
        #endregion
        public FrmServer()
        {
            InitializeComponent();
        }
        #region Form's Event
        private void FrmServer_Load(object sender, EventArgs e)
        {
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
        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            if (Server.ServerStatus == TcpServer.Status.Online)
            {
                MessageBox.Show("Server's Already Opened!");
                return;
            }
            Task _openserver = Server.Open(GetServerEP());
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
                lbServerStatus.Text = "ONLINE!";
            }
        }
        private void Server_Closed(object sender, EventArgs e)
        {
            lock (lbServerStatus)
            {
                lbServerStatus.Text = "OFFLINE!";
            }
        }
        private void Server_Received(object sender, EventArgs e)
        {
            
        }
        private void Server_Accepted(object sender, EventArgs e)
        {

        }
        private void Server_ReceivedTimeouted(object sender, EventArgs e)
        {
        }
        private void Server_Sended(object sender, EventArgs e)
        {
        }
        private void Server_SendTimeouted(object sender, EventArgs e)
        {
        }
        #endregion
        #region Vision
        public byte[] Processing(byte[] receivedData)
        {
            byte[] data = null;
            try
            {

            }
            catch (Exception ex)
            {

            }
            return data;
        }
        #endregion

    }
}
