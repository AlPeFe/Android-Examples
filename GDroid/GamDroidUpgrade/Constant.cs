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

namespace GamDroidUpgrade
{
    public static class Constant
    {
        public const int DELAY_BETWEEN_WEBSERVICE_CALLS = 30000; // milisegundos

        public const int DELAY_BETWEEN_SENDING_DATA = 30000; // milisegundos

        public const int DELAY_BETWEEN_GPS_UPDATES = 1000;//500 * 60 * 1; //30 sec

        public const float MIN_DISTANCE_GPS_UPDATES = 10; //1.5 metros

        public const string LOG_EXCEPTION_PATH = "";

        public const string LOG_PATH = "";
    }
}