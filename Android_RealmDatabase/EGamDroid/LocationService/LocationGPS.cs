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
using Android.Util;

namespace EGamDroid.LocationService
{
    [Service(Name ="com.eGamdroid.application.LocationGPS")]
    public class LocationGPS : Service, ILocationListener
    {
        private LocationManager lm;
        private double latitude;
        private double longitude;
        private double accuracy;
        private Handler _handler;

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        public void OnLocationChanged(Location location)
        {
            latitude = location.Latitude;
            longitude = location.Longitude;
            accuracy = location.Accuracy;
        }

        public void OnProviderDisabled(string provider)
        {
            Toast.MakeText(ApplicationContext, "Activa el GPS", ToastLength.Long).Show();          
        }

        public void OnProviderEnabled(string provider)
        {
            lm.RequestLocationUpdates(LocationManager.GpsProvider, 10000, 10f, this);
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {

        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            lm = (LocationManager)this.GetSystemService(Context.LocationService);
            lm.RequestLocationUpdates(LocationManager.GpsProvider, 1000, 10f, this);
            lm.RequestLocationUpdates(LocationManager.NetworkProvider, 1000, 300f, this);

            return base.OnStartCommand(intent, flags, startId);
        }
    }
}