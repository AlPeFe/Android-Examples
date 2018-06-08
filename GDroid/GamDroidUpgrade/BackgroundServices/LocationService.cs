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
using GamDroidUpgrade.Database.LocalDb;


namespace GamDroidUpgrade.BackgroundServices
{
    [Service]
    public class LocationService : Service, ILocationListener //servicio que se encarga de la localización GPS 
    {
        LocationManager _locationManager;
        Location _currentLocation;
        IGamDroidLite _gamDroidLite;

        public LocationService() : this(new GamDroidLite()) { }

        internal LocationService(IGamDroidLite gamDroidLite)
        {
            _gamDroidLite = gamDroidLite;
        }
       
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            _locationManager.RequestLocationUpdates(LocationManager.GpsProvider, Constant.DELAY_BETWEEN_GPS_UPDATES, 0, this); //aqui se tiene que configurar para las request al GPS, los valores estan en las constantes
            _locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, Constant.DELAY_BETWEEN_GPS_UPDATES, 0, this); // de momento el network se deja comentado

            return base.OnStartCommand(intent, flags, startId);
        }

        public void OnLocationChanged(Location location)
        {
            try
            {
                _currentLocation = location;

                if (_currentLocation != null)
                {
                    //var lat = _currentLocation.Latitude;
                    //var lon = _currentLocation.Longitude; // localización actual que da el GPS

                    _gamDroidLite.DeleteLocations(); //comprueba si tiene mas de 500 posiciones y borra

                    _gamDroidLite.StoreLocation(
                        new Database.Tables.Location
                        {
                            Date = DateTime.Now,
                            Latitude = _currentLocation.Latitude,
                            Longitude = _currentLocation.Longitude
                        });
                }

            }catch(Exception ex)
            {
                Toast.MakeText(this, "Error al guardar la posicion", ToastLength.Long);
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