using Android.App;
using Android.Widget;
using Android.OS;
using AdvertiserOverlay.Model;
using Android.Support.V7.App;

namespace AdvertiserOverlay
{
    [Activity(Label = "AdvertiserOverlay", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ConfigurationManager _configuration;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _configuration = new ConfigurationManager();


            if (_configuration.GetConfiguration() == null)
            {
                StartActivity(typeof(Screens.AppSettings));
                Finish();
            }
            else
            {
                StartService(new Android.Content.Intent("DecathlonService.Advertising"));

                Finish();
            }
        }
    }
}

