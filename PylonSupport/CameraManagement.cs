using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Basler.Pylon;

namespace PylonSupport
{
    public class CameraManagement
    {
        #region Event
        public event EventHandler CamChanged;
        public event EventHandler CamListChanged;
        public event EventHandler CamDisposing;
        public event EventHandler CamDispoed;
        
        public void OnCameraChanged()
        {
            CamChanged?.Invoke(this.PyCamera,EventArgs.Empty);
        }
        public void OnCamListChanged()
        {
            CamListChanged?.Invoke(this, EventArgs.Empty);
            //Thread thread = new Thread(() => { CamListChanged?.Invoke(this, EventArgs.Empty); });
            //thread.Start();
        }
        public void OnCamDisposing()
        {
            CamDisposing?.Invoke(this, EventArgs.Empty);
        }
        public void OnCamDisposed()
        {
            CamDispoed?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region Field
        public bool EnableUpdateDeviceList { get; set; } = false;
        #endregion
        public LCamera PyCamera { get; set; }
        public List<ICameraInfo> CurCameraInfoList { get; set; }
        public CameraManagement()
        {
            CurCameraInfoList = new List<ICameraInfo>();
        }
        public CameraManagement(ICameraInfo info)
        {
            PyCamera = new LCamera(info);
            CurCameraInfoList = new List<ICameraInfo>();
        }
        public CameraManagement(LCamera pyCamera)
        {
            CurCameraInfoList = new List<ICameraInfo>();
            PyCamera = pyCamera;
        }
        private void OneShot()
        {
            try
            {
                // Starts the grabbing of one image.
                Configuration.AcquireSingleFrame(PyCamera, null);
                PyCamera.StreamGrabber.Start(1, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception exception)
            {
            }
        }
        public void Open(ICameraInfo info)
        {
            if(this.PyCamera != null)
            {
                DestroyCamera();
            }
            PyCamera = new LCamera(info);
            this.OnCameraChanged();
        }
        private void Stop()
        {
            // Stop the grabbing.
            try
            {
                PyCamera.StreamGrabber.Stop();
            }
            catch (Exception exception)
            {
            }
        }
        public void DestroyCamera()
        {
            // Disable all parameter controls.
            try
            {
                if (PyCamera != null)
                {

                }
            }
            catch (Exception exception)
            {
            }

            // Destroy the camera object.
            try
            {
                if (PyCamera != null)
                {
                    PyCamera.Close();
                    PyCamera.Dispose();
                    PyCamera = null;
                }
            }
            catch (Exception exception)
            {
            }
        }
        public void UpdateDeviceList()
        {
            if (!EnableUpdateDeviceList) return;
            try
            {
                bool found = false;
                bool hasnewon = false;
                List<ICameraInfo> camerainfos = CameraFinder.Enumerate();
                if(this.CurCameraInfoList.Count == 0 && camerainfos.Count > 0)
                {
                    this.CurCameraInfoList = camerainfos;
                    OnCamListChanged();
                }
                else
                {
                    foreach(ICameraInfo curinfo in CurCameraInfoList)
                    {
                        found = false;
                        foreach(ICameraInfo info in camerainfos)
                        {
                            if (curinfo[CameraInfoKey.SerialNumber] == info[CameraInfoKey.SerialNumber])
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            hasnewon = true;
                            break;
                        }
                    }
                    if (hasnewon)
                    {
                        CurCameraInfoList = camerainfos;
                        OnCamListChanged();
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
