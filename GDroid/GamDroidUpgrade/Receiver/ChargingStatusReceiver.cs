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

namespace GamDroidUpgrade.Receiver
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionPowerConnected, Intent.ActionPowerDisconnected })]
    public class ChargeStatusReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent) //detecta si se ha conectado o desconectado el cargador del dispositivo
        {
           if(intent.Action == Intent.ActionPowerDisconnected)
            {
                Toast.MakeText(context, "Carga desconectada", ToastLength.Long).Show(); //esto debería generar trama en principio
            }
        }
    }
}