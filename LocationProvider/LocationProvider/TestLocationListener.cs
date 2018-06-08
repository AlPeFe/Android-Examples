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

namespace LocationProvider
{
    public class TestLocationListener : Java.Lang.Object, ILocationListener
    {     
        public void OnLocationChanged(Location location)
        {
            Log.Debug("s", "Location changed: " + DateTime.Now + " " + location.Longitude+ "-"+location.Latitude);
        }

        public void OnProviderDisabled(string provider)
        {
            Log.Debug("s", "ProviderDisabled");
        }

        public void OnProviderEnabled(string provider)
        {
            Log.Debug("s", "ProviderEnabled");
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            Log.Debug("s", "NewStatus");
        }
    }
}