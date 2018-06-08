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
using GamDroidUpgrade.Database.LocalDb;
using Android.Support.V4.App;

namespace GamDroidUpgrade.Sync
{
    [Service]
    [IntentFilter(new String[] { "gam.WebService" })]
    public class GamRetrieve : Service
    {
        Handler _handler;
        Action _runnable;
        GamWs.GamWs _service; //WebService
        IGamDroidLite _gamDroidLite;
        NotificationManager _notificationManager;
        int netWorkNotificationID = 1; //los ids para las notificaciones, de esta forma no las tengo que crear cada vez sino updatear
        int webServiceNotificationID = 2;
        int deviceNotificationID = 3;

        public GamRetrieve() : this(new GamDroidLite()) { }

        internal GamRetrieve(IGamDroidLite gamDroidLite)
        {
            _gamDroidLite = gamDroidLite;
        }

        public override void OnCreate()
        {
            _handler = new Handler();
            _notificationManager = (NotificationManager)GetSystemService(NotificationService); //se crea el manager y se recoge el servicio de notificaciones
            
            if ((_notificationManager != null)) //por si acaso el dispositivo no tiene este servicio aunque seria muy raro
            {
                SetUpNotifications(); //genera notificaciones
            }

            _service = new GamWs.GamWs { Url = "http://roma/GamService/Service.svc?wsdl" };//_gamDroidLite.GetDeviceSettings()?.UrlWs?? ""}; //pone la URL del config si este existe

            _runnable = new Action(() =>
            {
                InboxService();
                _handler.RemoveCallbacks(_runnable);
                _handler.PostDelayed(_runnable, Constant.DELAY_BETWEEN_WEBSERVICE_CALLS);
            });

            base.OnCreate();
        }

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            _handler.PostDelayed(_runnable, Constant.DELAY_BETWEEN_WEBSERVICE_CALLS);

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            _handler.RemoveCallbacks(_runnable);

            base.OnDestroy();
        }

        private void InboxService()
        {
            Toast.MakeText(this, "Recuperando información WebService", ToastLength.Long).Show();
        }

        private void SetUpNotifications()
        {
            UpdateNotification(netWorkNotificationID, new NotificationCompat.Builder(this).SetContentText("Online").SetContentTitle("NetworkStatus").SetSmallIcon(Resource.Drawable.abc_action_bar_item_background_material).SetOngoing(true));
            UpdateNotification(netWorkNotificationID, new NotificationCompat.Builder(this).SetContentText("250").SetContentTitle("Vehículo").SetSmallIcon(Resource.Drawable.abc_action_bar_item_background_material).SetOngoing(true));
            UpdateNotification(netWorkNotificationID, new NotificationCompat.Builder(this).SetContentText("Pepe Antonio").SetContentTitle("TES").SetSmallIcon(Resource.Drawable.abc_action_bar_item_background_material).SetOngoing(true));
        }

        private void UpdateNotification(int NotificationId, NotificationCompat.Builder builder)
        {
            _notificationManager.Notify(NotificationId, builder.Build());
        }
    }
}