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
using Android.Net.Wifi;

namespace AndroidTest
{
    [BroadcastReceiver(Enabled = true)] 
    [IntentFilter( new [] { Intent.ActionPowerConnected, Intent.ActionPowerDisconnected})]
    public class ChargeStatusReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Cargador", ToastLength.Long).Show();
        }
    }
}