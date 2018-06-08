using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace LocationProvider
{
    [Activity(Label = "LocationProvider", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            StartService(new Android.Content.Intent("com.Location.Gam"));
        }
    }
}

