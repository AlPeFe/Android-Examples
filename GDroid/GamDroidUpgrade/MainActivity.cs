using Android.App;
using Android.Widget;
using Android.OS;
using GamDroidUpgrade.Database;
using Android.Content;
using GamDroidUpgrade.BackgroundServices;
using GamDroidUpgrade.Database.LocalDb;
using GamDroidUpgrade.Utils;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using GamDroidUpgrade.Sync;
using GamDroidUpgrade.Screens;

namespace GamDroidUpgrade
{
    [Activity(Label = "GamDroidUpgrade", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button _button;
        EditText _textArea;
        IGamDroidLite _GamDroidlite;

        public MainActivity() : this(new GamDroidLite()){ }

        internal MainActivity(IGamDroidLite gamDroidLite)
        {
            _GamDroidlite = gamDroidLite;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Auto.Boot();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            StartService(new Intent(this, typeof(LocationService)));
            StartService(new Intent(this, typeof(GamRetrieve)));

            GamDroidDb db = new GamDroidDb();
           
            _button = FindViewById<Button>(Resource.Id.btnC);

            _textArea = FindViewById<EditText>(Resource.Id.area);

            _button.Click += delegate
            {
                StartActivity(typeof(MenuActivity));               
            };
        }
    }
}

