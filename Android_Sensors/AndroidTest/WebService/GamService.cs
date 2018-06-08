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
using WebReference = AndroidTest.GamWs.GamWs;


namespace AndroidTest.WebService
{
    [Service]
    [IntentFilter(new String[] { "gam.WebService" })]
    public class GamService : Service
    {
        Handler _handler;
        Action _runnable;
        WebReference _service; //WebService

        public override void OnCreate()
        {
            _handler = new Handler();

            _service = new WebReference { Url = "" }; //sets the URL of the host old url config

            _runnable = new Action(() =>
            {
                InboxService();
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
            _handler.PostDelayed(_runnable, Constantes.DELAY_BETWEEN_WEBSERVICE_CALLS);

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            _handler.RemoveCallbacks(_runnable);

            base.OnDestroy();
        }

        private void InboxService()
        {

            


        }
    }
}