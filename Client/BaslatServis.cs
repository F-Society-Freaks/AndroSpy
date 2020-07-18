using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace izci
{
    [Service]
    public class BaslatServis : Service
    {
        static readonly Type SERVICE_TYPE = typeof(ForegroundService);
        static Intent _startServiceIntent;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            baslat();
            return StartCommandResult.Sticky;
        }
        public async void baslat()
        {
            PackageManager p = PackageManager;
            ComponentName componentName = new ComponentName(this,
            Java.Lang.Class.FromType(typeof(MainActivity)).Name);
            p.SetComponentEnabledSetting(componentName,
            ComponentEnabledState.Enabled, ComponentEnableOption.DontKillApp);
            await System.Threading.Tasks.Task.Delay(8000);
            Intent start = new Intent(this, typeof(MainActivity));
            start.AddFlags(ActivityFlags.NewTask);
            StartActivity(start);
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
        }
        private Intent GetIntent(Type type, string action)
        {
            var intent = new Intent(this, type);
            intent.SetAction(action);
            return intent;
        }
        public void StartForegroundServiceCompat<T>(Context context, Bundle args = null) where T : Service
        {
            _startServiceIntent = GetIntent(SERVICE_TYPE, MainValues.ACTION_START_SERVICE);

            if (args != null)
                _startServiceIntent.PutExtras(args);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                context.StartForegroundService(_startServiceIntent);
            else
                context.StartService(_startServiceIntent);
        }
    }
}