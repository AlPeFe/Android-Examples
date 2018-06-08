


namespace GamDroid.Utils
{  
    [Service]
    [IntentFilter(new string[] { "Background.service" })]
    public class ThreadInbox : Service
    {
        private Handler _handler;
        private Runnable _runnable;
        private GamWs.GamWs _gamWs;
        private HttpClient _httpClient;
        private NotificationManager _manager;
        private Notification _internet;
        private PendingIntent _intentNull;
        private LocationManager _locationManager;
        private WakeLock _wLock;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {

            PowerManager pwManager = GetSystemService(PowerService) as PowerManager;
            _wLock = pwManager.NewWakeLock(WakeLockFlags.Partial, "servicelock"); 
            _wLock.Acquire();          
            _gamWs = new GamWs.GamWs { Url = Configuration.Config.UrlWs };
            _httpClient = new HttpClient(new NativeMessageHandler());
            SetUpInternetNotification();

            return StartCommandResult.Sticky;
        }

        public override void OnCreate()
        {
            try
            { 
                _handler = new Handler();

                _runnable = new Runnable(() =>
                {
                    new Thread(() =>
                    {
                        try
                        {

                            ConsumeWebService();

                            _handler.PostDelayed(_runnable, 30000);
                        }
                        catch (System.Exception ex)
                        {
                            Log.Log.WriteError("ERROR THREAD - " + ex.Message + " " + ex.InnerException);
                            _handler.PostDelayed(_runnable, 30000);
                        }

                    }).Start();   
                    
                });

                _handler.PostDelayed(_runnable, 1000);
                            
            }
            catch(System.Exception ex)
            {
                var ms = ex.Message;
            }
            base.OnCreate();
        }

        private void ConsumeWebService()
        {          
           //aqui la función
        }

        private bool StatusConexion()
        {
            bool connectionStatus = false;

            try
            {          
                var response = _httpClient.GetAsync(Configuration.Config.UrlWs).Result;

                if (response != null && (int)response.StatusCode >= 200 && (int)response.StatusCode < 300)//== HttpStatusCode.OK)
                {
                    connectionStatus = true;
                }

                response.Dispose();
                
            }
            catch (System.Exception ex)
            {
                _httpClient.Dispose();
                _httpClient = new HttpClient(new NativeMessageHandler());
            }

            _internet.SetLatestEventInfo(this, "Estado Conexión", connectionStatus == true ? "Online" : "Offline", null);

            _manager.Notify(200, _internet);

            return connectionStatus;
        }

      
  
        public override void OnLowMemory()
        {
            Log.Log.WriteInfo("MEMORIA BAJA \n\r");
            base.OnLowMemory();
        }

        public override void OnDestroy()
        {
            Log.Log.WriteInfo("DESTROY ThreadInbox \n\r");
            
            _handler.RemoveCallbacks(_runnable);
            _wLock.Release();
            base.OnDestroy();
        }

        private void SetUpInternetNotification()
        {
            _manager = (NotificationManager)GetSystemService(Context.NotificationService);
            _intentNull = PendingIntent.GetActivity(this, 1, new Intent(), PendingIntentFlags.UpdateCurrent);
            _internet = new Notification(Resource.Drawable.internet_si, "Internet");
            _internet.Flags = NotificationFlags.OngoingEvent;
            _internet.SetLatestEventInfo(this, "Estado Conexión", "Offline", null);
        }
    }

   

}
