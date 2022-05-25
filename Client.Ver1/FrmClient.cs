using Basler.Pylon;
using LiteDB;
using PylonSupport;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using VisionSupport;

namespace Client.Ver1
{
    public partial class FrmClient : Form
    {
        #region Properties
        //Utilities variables
        private string OldtbxIPAddress { get; set; } = "";
        private Stopwatch swCaptureImage { get; set; }
        //
        public CameraManagement CameraManagement { get; set; }
        public System.Windows.Forms.Timer CheckCameraList { get; set; }
        public PixelDataConverter PixelDataConverter { get; set; }
        public TerminalCollection Output { get; set; }
        public TerminalCollection Input { get; set; }
        public TcpSupport.TcpClient Client { get; set; }
        DataCarrier SendDataCarrier { get; set; }
        #endregion
        public FrmClient()
        {
            InitializeComponent();
        }
        #region Form's Event
        private void FrmMain_Load(object sender, EventArgs e)
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
            Client = new TcpSupport.TcpClient();
            Client.Sended += Client_Sended;
            Client.Received += Client_Received;
            Client.Connected += Client_Connected;

            //Model Table
            this.ModelTable.ShowModelInfo();

            Output = new TerminalCollection();
            btnCapture.Enabled = false;
            CameraManagement = new CameraManagement();
            CameraManagement.CamListChanged += CameraManagement_CamListChanged;
            CameraManagement.CamChanged += CameraManagement_CamChanged;
            PixelDataConverter = new PixelDataConverter();
            CheckCameraList = new System.Windows.Forms.Timer();
            CheckCameraList.Interval = 1000;
            CheckCameraList.Tick += CheckCameraList_Tick;
            CheckCameraList.Start();
            cbPixelFormat.DefaultName = "Pixel Format";
            sliderExposure.DefaultName = "Exposure";
            sliderWidth.DefaultName = "Width";
            sliderHeight.DefaultName = "Height";
        }
        private void CheckCameraList_Tick(object sender, EventArgs e)
        {
            CameraManagement.EnableUpdateDeviceList = true;
            CameraManagement.UpdateDeviceList();
        }
        private void CameraManagement_CamChanged(object sender, EventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new EventHandler<EventArgs>(CameraManagement_CamChanged), sender, e);
                    return;
                }
                LCamera camera = CameraManagement.PyCamera;
                camera.CameraOpened += Configuration.AcquireContinuous;
                camera.ConnectionLost += Camera_ConnectionLost;
                camera.CameraOpened += Camera_CameraOpened;
                camera.CameraClosed += Camera_CameraClosed;
                camera.StreamGrabber.GrabStarted += StreamGrabber_GrabStarted;
                camera.StreamGrabber.ImageGrabbed += StreamGrabber_ImageGrabbed;
                camera.StreamGrabber.GrabStopped += StreamGrabber_GrabStopped;

                camera.Open();

                cbPixelFormat.Parameter = camera.Parameters[PLCamera.PixelFormat];
                sliderWidth.Parameter = camera.Parameters[PLCamera.Width];
                sliderHeight.Parameter = camera.Parameters[PLCamera.Height];
                if (camera.Parameters.Contains(PLCamera.ExposureTimeAbs))
                {
                    sliderExposure.Parameter = camera.Parameters[PLCamera.ExposureTimeAbs];
                }
                else
                {
                    sliderExposure.Parameter = camera.Parameters[PLCamera.ExposureTime];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CameraManagement_CamListChanged(object sender, EventArgs e)
        {
            if (dvCameraList.InvokeRequired)
            {
                dvCameraList.BeginInvoke(new EventHandler<EventArgs>(CameraManagement_CamListChanged), sender, e);
                return;
            }
            dvCameraList.Rows.Clear();
            foreach (ICameraInfo info in CameraManagement.CurCameraInfoList)
            {
                DataGridViewRow newrow = new DataGridViewRow();
                DataGridViewTextBoxCell namecell = new DataGridViewTextBoxCell();
                namecell.Value = info[CameraInfoKey.ModelName];
                DataGridViewTextBoxCell serialcell = new DataGridViewTextBoxCell();
                serialcell.Value = info[CameraInfoKey.SerialNumber];
                newrow.Cells.AddRange(new DataGridViewCell[2] { namecell, serialcell });
                dvCameraList.Rows.Add(newrow);
            }
        }
        private void dvCameraList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            if (MessageBox.Show("Change Camera!", "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            CameraManagement.Open(CameraManagement.CurCameraInfoList[index]);
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            Thread _click = new Thread(() =>
            {
                if (!CameraManagement.PyCamera.Parameters[PLCamera.AcquisitionMode].CanSetValue("SingleFrame"))
                {
                    MessageBox.Show("false");
                    return;
                }
                long connecttime = 0;
                if (!Client.Connect(GetServerEP(), out connecttime))
                {
                    MessageBox.Show("Cannot connect to Server!");
                }
                CalTaktTime("Connect", connecttime, true);//->takt time
            });
            _click.Start();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CameraManagement.DestroyCamera();
        }
        class IPData
        {
            public int Id { get; set; }
            public string IP { get; set; }
        }
        private void textBox1_Leave(object sender, EventArgs e)
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
            catch (ArgumentException aex)
            {
                LMessageBox.Ver1.LMessageBox.Show("IP is invalid", "Warning");
                //MessageBox.Show("IP is invalid");
                tbxIPAddress.Text = OldtbxIPAddress;
            }
        }
        private void tbxIPAddress_Enter(object sender, EventArgs e)
        {
            OldtbxIPAddress = tbxIPAddress.Text;
        }
        #endregion
        #region Form's Method
        public void CalTaktTime(string name, long value, bool enableAccumulate)
        {
            Thread _thread = new Thread(() => { TaktTable.AddTime(name, value, enableAccumulate); });
            _thread.Start();
        }
        public void ShowImage(PictureBox display, Bitmap image)
        {
            if (display.InvokeRequired)
            {
                display.BeginInvoke(new Action<PictureBox, Bitmap>(ShowImage), display, image);
                return;
            }
            Stopwatch swshowimage = new Stopwatch();
            swshowimage.Start();
            display.BackgroundImage = image;
            swshowimage.Stop();
            CalTaktTime("Show Image", swshowimage.ElapsedMilliseconds, false);
        }
        #endregion
        #region CameraEvent
        private void Camera_CameraOpened(object sender, EventArgs e)
        {
            if (btnCapture.InvokeRequired)
            {
                btnCapture.BeginInvoke(new EventHandler<EventArgs>(Camera_CameraOpened), sender, e);
                return;
            }
            btnCapture.Enabled = true;
            lock (lbCameraStatus)
            {
                lbCameraStatus.Text = $"{CameraManagement.PyCamera.CameraInfo[CameraInfoKey.ModelName]} ONLINE!";
            }
        }
        private void Camera_CameraClosed(object sender, EventArgs e)
        {
            if (btnCapture.InvokeRequired)
            {
                btnCapture.BeginInvoke(new EventHandler<EventArgs>(Camera_CameraClosed), sender, e);
                return;
            }
            btnCapture.Enabled = false;
            lock (lbCameraStatus)
            {
                CameraManagement.DestroyCamera();
                lbCameraStatus.Text = $"OFLINE!";
            }
        }
        private void Camera_ConnectionLost(object sender, EventArgs e)
        {
            if (btnCapture.InvokeRequired)
            {
                btnCapture.BeginInvoke(new EventHandler<EventArgs>(Camera_ConnectionLost), sender, e);
                return;
            }
            btnCapture.Enabled = false;
            lock (lbCameraStatus)
            {
                CameraManagement.DestroyCamera();
                lbCameraStatus.Text = $"OFLINE!";
            }
        }
        private void StreamGrabber_GrabStarted(object sender, EventArgs e)
        {
            if (btnCapture.InvokeRequired)
            {
                btnCapture.BeginInvoke(new EventHandler<EventArgs>(StreamGrabber_GrabStarted), sender, e);
                return;
            }
            btnCapture.Enabled = false;
            CameraManagement.EnableUpdateDeviceList = false;
        }
        private void StreamGrabber_ImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                if (swCaptureImage != null)
                {
                    swCaptureImage.Stop();
                    CalTaktTime("Grab Image", swCaptureImage.ElapsedMilliseconds, true);
                }
                IGrabResult grabResult = e.GrabResult;
                if (grabResult.IsValid)
                {
                    long converttime = 0;//->takt time
                    Bitmap bitmap = ImageConvert.ConvertToBitmap(e.GrabResult, PixelDataConverter, out converttime);
                    CalTaktTime("Convert", converttime, false);//->takt time
                    CameraDisplay.BackgroundImage = bitmap.Clone() as Bitmap;
                    Output.Clear();
                    Output.Add(new Terminal("Image", bitmap, typeof(Bitmap)));
                    SendDataCarrier = new DataCarrier("0x01", Output);
                    long encodeOutput = 0;
                    byte[] sendata = Serialize.Serialize.SerializeDataCarrerier(SendDataCarrier, out encodeOutput);
                    CalTaktTime("Encode", encodeOutput, true);//->takt time
                    Client.Send(Client.Client, sendata);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StreamGrabber_GrabStopped(object sender, GrabStopEventArgs e)
        {
            if (btnCapture.InvokeRequired)
            {
                btnCapture.BeginInvoke(new EventHandler<GrabStopEventArgs>(StreamGrabber_GrabStopped), sender, e);
                return;
            }
            btnCapture.Enabled = true;
            CameraManagement.EnableUpdateDeviceList = true;
        }
        #endregion
        #region TCP
        private void Client_Connected(object sender, EventArgs e)
        {
            try
            {
                Configuration.AcquireSingleFrame(CameraManagement.PyCamera, null);
                swCaptureImage = new Stopwatch();
                swCaptureImage.Start();
                CameraManagement.PyCamera.StreamGrabber.Start(1, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ex)
            {

            }
        }
        private void Client_Received(object sender, EventArgs e)
        {
            if (CameraDisplay.InvokeRequired)
            {
                CameraDisplay.BeginInvoke(new EventHandler<EventArgs>(Client_Received), sender, e);
                return;
            }
            long receivetakttime = ((TcpSupport.TcpBase.TcpReceiveArgs)e).TaktTime;
            byte[] receivedata = ((TcpSupport.TcpBase.TcpReceiveArgs)e).Data;
            TaktTable.AddTime("Receive", receivetakttime, true);
            TaktTable.AddTime("Receive Data", receivetakttime, true);
            if (receivedata.Length > 0)
            {
                long deserializetime = 0;
                Input = Serialize.Serialize.DeserializeTerminalCollection(receivedata, out deserializetime);
                CalTaktTime("Deserialize", deserializetime, true);
                InputTerminalTable.SetValue2View(Input);
                if (!Input.ContainsKey("Image")) return;
                if (Input["Image"].Value == null) return;
                CameraDisplay.BackgroundImage = (Input["Image"].Value as Bitmap).Clone() as Bitmap;
            }
        }
        private void Client_Sended(object sender, EventArgs e)
        {
            long sendtakttime = ((TcpSupport.TcpBase.TcpSendArgs)e).TaktTime;
            TaktTable.AddTime("Send", sendtakttime, true);
            Client.Receive(Client.Client);
        }
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

    }
}