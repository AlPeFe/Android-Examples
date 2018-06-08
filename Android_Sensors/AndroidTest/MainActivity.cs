using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Content;
using Android.Net.Wifi;
using AndroidTest.Database;
using AndroidTest.Database.Tables;

namespace AndroidTest
{
    [Activity(Label = "AndroidTest", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class MainActivity : Activity
    {
        
        private Button _button;
        private TextView _text;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //StartService(new Intent(this, typeof(LocationService)));

            //StartService(new Intent(this, typeof(SensorService)));
            //StartService(new Intent("gam.WebService"));

            SetContentView(Resource.Layout.Main);

            GamDroidDb db = new GamDroidDb();
            db.Insert(new Location { latitude = 245, longitude = 123, hola = "sdfsdfdsfds" });

           _button = FindViewById<Button>(Resource.Id.btnC);

            _text = FindViewById<TextView>(Resource.Id.textView1);

            _button.Click += delegate
            {

              var res =  db.Table<Location>().FirstOrDefault();

                _text.Text =res.hola;

            };


                
        }

        protected override void OnResume()
        {



            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
    }
}

