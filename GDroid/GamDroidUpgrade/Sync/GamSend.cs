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

namespace GamDroidUpgrade.Sync
{
    [Service]
    [IntentFilter(new String[] { "outService" })]
    public class GamSend : Service
    {
        IGamDroidLite _gamDroidLite;
        Handler _handler;
        Action _runnable;
        GamWs.GamWs _service; //WebServices

        public GamSend() : this(new GamDroidLite()) { }

        internal GamSend(IGamDroidLite gamDroidLite)
        {
            _gamDroidLite = gamDroidLite;
        }

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        public override void OnCreate()
        {
            _handler = new Handler();

            _service = new GamWs.GamWs { Url = "http://roma/GamService/Service.svc?wsdl" };//_gamDroidLite.GetDeviceSettings()?.UrlWs ?? "" }; //pone la URL del config si este existe

            _runnable = new Action(() =>
            {
                //SendLocalData();
                _handler.RemoveCallbacks(_runnable);
                _handler.PostDelayed(_runnable, Constant.DELAY_BETWEEN_SENDING_DATA);
            });

            base.OnCreate();
        }

        public override void OnDestroy()
        {
            _handler.RemoveCallbacks(_runnable);
            base.OnDestroy();
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            _handler.PostDelayed(_runnable, Constant.DELAY_BETWEEN_SENDING_DATA);


            return StartCommandResult.Sticky;
        }

     
    }
}