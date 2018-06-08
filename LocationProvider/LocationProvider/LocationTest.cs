using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;
using System.Threading;

namespace LocationProvider
{
    [Service]
    [IntentFilter(new string[] { "com.Location.Gam" })]
    public class LocationTest : Service
    {
        public LocationManager _locationManager;
        public TestLocationListener _listener;
        Thread thread;
        private Handler handler;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {

            handler = new Handler();
            thread = new Thread(() =>
            {
                _locationManager = (LocationManager)GetSystemService(LocationService);
                _listener = new TestLocationListener();
                
                handler.Post(() =>
                {
                    _locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 10000, 0, _listener);

                });
            });

            thread.Start();


            return StartCommandResult.Sticky;
        }

      
    }
}