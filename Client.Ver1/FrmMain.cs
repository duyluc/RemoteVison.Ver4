using Basler.Pylon;
using PylonSupport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Ver1
{
    public partial class FrmMain : Form
    {
        #region Properties
        public CameraManagement CameraManagement { get; set; }
        public Timer CheckCameraList { get; set; }
        public PixelDataConverter PixelDataConverter { get; set; }
        #endregion
        public FrmMain()
        {
            InitializeComponent();
        }
        #region Form's Event
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.btnCapture.Enabled = false;
            CameraManagement = new CameraManagement();
            CameraManagement.CamListChanged += CameraManagement_CamListChanged;
            CameraManagement.CamChanged += CameraManagement_CamChanged;
            PixelDataConverter = new PixelDataConverter();
            CheckCameraList = new Timer();
            CheckCameraList.Interval = 1000;
            CheckCameraList.Tick += CheckCameraList_Tick;
            CheckCameraList.Start();
            this.cbPixelFormat.DefaultName = "Pixel Format";
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
            catch(Exception ex)
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
            foreach(ICameraInfo info in CameraManagement.CurCameraInfoList)
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
            if (!CameraManagement.PyCamera.Parameters[PLCamera.AcquisitionMode].CanSetValue("SingleFrame"))
            {
                MessageBox.Show("false");
                return;
            }
            Configuration.AcquireSingleFrame(CameraManagement.PyCamera, null);
            CameraManagement.PyCamera.StreamGrabber.Start(1, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CameraManagement.DestroyCamera();
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
                if (CameraDisplay.InvokeRequired)
                {
                    CameraDisplay.BeginInvoke(new EventHandler<ImageGrabbedEventArgs>(StreamGrabber_ImageGrabbed), sender, e.Clone());
                    return;
                }
                IGrabResult grabResult = e.GrabResult;
                if (grabResult.IsValid)
                {
                    Bitmap bitmap = ImageConvert.ConvertToBitmap(e.GrabResult, this.PixelDataConverter);
                    CameraDisplay.BackgroundImage = bitmap;
                }
                CameraManagement.PyCamera.StreamGrabber.Stop();
            }
            catch(Exception ex)
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
    }
}