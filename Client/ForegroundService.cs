using Android.App;
using Android.Content;
using Android.OS;
using Android.Hardware.Camera2;
using Android.Runtime;
using System.Threading.Tasks;
using Android.Content.PM;
using Android.Widget;

namespace izci
{
    [Service]
	public class ForegroundService : Service
	{
        HiddenCamera _hiddenCamera;
        public override void OnCreate()
        {
            base.OnCreate();
            //RunTask(MainValues.PERIOD_IN_MINUTES);
            //int dk = int.Parse(Resources.GetString(Resource.String.DK));
            RunTask(0);
        }

        public override IBinder OnBind(Intent intent)
            => null;

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            if (intent.Action.Equals(MainValues.ACTION_START_SERVICE))
            {
                Notification notification;
                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    CreateNotificationChannel();
                    notification = CreateNotificationWithChannelId();
                }
                else
                    notification = CreateNotification();

                StartForeground(MainValues.SERVICE_RUNNING_NOTIFICATION_ID, notification);
            }
            //else if (intent.Action.Equals(Constants.ACTION_STOP_SERVICE))
            //    _hiddenCamera.Stop();
            PowerManager pm = (PowerManager)GetSystemService(PowerService);
            PowerManager.WakeLock wl = pm.NewWakeLock(WakeLockFlags.Partial, "THT");
            wl.Acquire();
            //test();
            return StartCommandResult.Sticky;
        }
        /*
        public async void test()
        {
            PackageManager p = PackageManager;
            ComponentName componentName = new ComponentName(ApplicationContext, 
            Java.Lang.Class.FromType(typeof(MainActivity)).Name);
            p.SetComponentEnabledSetting(componentName,
            ComponentEnabledState.Enabled, ComponentEnableOption.DontKillApp);

            Toast.MakeText(this, "GOSTERILIYOR", ToastLength.Long).Show();

            await Task.Delay(15000);
            Intent start1 = new Intent(this, typeof(MainActivity));
            start1.AddFlags(ActivityFlags.NewTask);
            StartActivity(start1);
        }
        */
        public override void OnDestroy()
        {
            base.OnDestroy();
            StopTask();
        }

        private void CreateNotificationChannel()
        {
            var notificationChannel = new NotificationChannel
                (
                    MainValues.NOTITFICATION_CHANNEL_ID,
                    MainValues.NOTIFICATION_CHANNEL_NAME,
                    NotificationImportance.Default
                );
            notificationChannel.LockscreenVisibility = NotificationVisibility.Secret;
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(notificationChannel);
        }

        private Notification CreateNotification()
        {
            var notification = new Notification.Builder(this)
                    .SetContentTitle(Resources.GetString(Resource.String.app_name))
                    .SetContentText(Resources.GetString(Resource.String.notification_text))
                    .SetSmallIcon(Resource.Drawable.ic_stat_name)
                    .SetOngoing(true)
                    .Build();

            return notification;
        }

        private Notification CreateNotificationWithChannelId()
        {
            var notification = new Notification.Builder(this, MainValues.NOTITFICATION_CHANNEL_ID)
               .SetContentTitle(Resources.GetString(Resource.String.app_name))
               .SetContentText(Resources.GetString(Resource.String.notification_text))
               .SetSmallIcon(Resource.Drawable.ic_stat_name)
               .SetOngoing(true)
               .Build();

            return notification;
        }

        private void RunTask(int minutes)
        {
            var cameraManager = (CameraManager)GetSystemService(CameraService);
            _hiddenCamera = new HiddenCamera(cameraManager);
            UpdateTimeTask._hiddenCamera = _hiddenCamera;
            //TimerPhotography(minutes);
        }

        private void StopTask()
        {
            //if (_timeTask != null)
              //  _timeTask.Stop();
        }

        private void TimerPhotography(int seconds)
        {
            //var timer = new Java.Util.Timer();
            //_timeTask = new UpdateTimeTask(_hiddenCamera);
            //timer.Schedule(_timeTask, 0, seconds * 60000);
        }
    }
}
