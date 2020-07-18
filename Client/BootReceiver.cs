using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Widget;
using System.Threading.Tasks;

namespace izci
{
    [BroadcastReceiver(Enabled = true, DirectBootAware = true, Exported = true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted }, Priority = (int)IntentFilterPriority.HighPriority)]
    public class BootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {            
            Toast.MakeText(context, "BOOT RECEIVED", ToastLength.Long).Show();          
            Intent start = new Intent(context, typeof(BaslatServis));
            start.AddFlags(ActivityFlags.NewTask);
            context.StartService(start);
            
        }
    }
}