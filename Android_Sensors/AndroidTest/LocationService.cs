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

namespace AndroidTest
{
    [Service]
    public class LocationService : Service, ILocationListener
    {
        LocationManager _locationManager;
        Location _currentLocation;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);        
            _locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 0,0,this);
            _locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 0, 0, this);
                 
            return base.OnStartCommand(intent, flags, startId);
        }

        public void OnLocationChanged(Location location)
        {
            _currentLocation = location;

            if(_currentLocation != null)
            {
               var lat =  _currentLocation.Latitude;
               var lon =  _currentLocation.Longitude;

            }
        }

        public void OnProviderDisabled(string provider)
        {


          
        }

        public void OnProviderEnabled(string provider)
        {


          
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
          

        }
    }
}