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
using AdvertiserOverlay.Model;
using Android.Graphics;
using Android.Media;

namespace AdvertiserOverlay.BackGroundWorker
{

    [Service]
    [IntentFilter(new string[] { "DecathlonService.Advertising" })]
    public class BackgroundService : Service
    {
        private ConfigurationManager _configuration;
        private LinearLayout transparentLayout;
        private LinearLayout advertisingLayout;
        IWindowManager _windowManager;
        WindowManagerLayoutParams _param;
        WindowManagerLayoutParams _displayParam;
        View _advertisingView;
        VideoView mVideoView;
        Button mButton;
        Handler _handler;
        Action _action;
        ConfigurationManager configuration = new ConfigurationManager();
        private static string video = ""; 
        

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {          
            return base.OnStartCommand(intent, flags, startId);
        }

        public override void OnCreate()
        {
            base.OnCreate();

            _handler = new Handler();

            _configuration = new ConfigurationManager();
          
            _windowManager = GetSystemService(WindowService).JavaCast<IWindowManager>();

            DisplayInvisibleLayout();       
        }

        private void StartTimer()//inicia el timer del handler
        {
            _handler.RemoveCallbacks(_action);
            _handler.PostDelayed(_action, configuration.Timer);
        } 
     
        public void DisplayAdvertising() //funcion que muestra la publicidad, es un layout inflado
        {

            try
            {               
                var layout = VideoViewInstance(); //devuelve la vista con el video incorporado
               
                _displayParam = new WindowManagerLayoutParams(
                           WindowManagerLayoutParams.MatchParent,
                           WindowManagerLayoutParams.MatchParent,
                           WindowManagerTypes.Phone,
                           WindowManagerFlags.Fullscreen, Format.Transparent);
                _displayParam.Gravity = GravityFlags.Center;

                if (transparentLayout != null)
                {
                    _windowManager.RemoveViewImmediate(transparentLayout);
                }

                _windowManager.AddView(layout, _displayParam);
             
                mVideoView.Start(); //esto es asincrono

                mVideoView.Prepared += delegate
                {
                    mButton.Visibility = ViewStates.Visible;
                   
                };

                mVideoView.Completion += delegate
                {
                    mVideoView.StopPlayback();
                    mVideoView.SetVideoURI(Android.Net.Uri.Parse(GetVideoUrl.GetUrlBySection(_configuration.GetConfigurationSection())));
                    mVideoView.Start();
                };

                

            }
            catch(Exception ex)
            {

            }
        }

        public void DisplayInvisibleLayout() //Muestra el layout invisible para los eventos outside TOUCH
        {
            transparentLayout = new LinearLayout(this);

            _action = DisplayAdvertising;

            StartTimer();

            transparentLayout.Touch += (s, e) =>
            {    
                StartTimer();
            };
            
            _param = new WindowManagerLayoutParams( //layout params de la vista "invisible" solo para el evento touch
                        1,
                        1,
                        WindowManagerTypes.Phone,
                        WindowManagerFlags.NotFocusable |
                        WindowManagerFlags.NotTouchModal |
                        WindowManagerFlags.WatchOutsideTouch,
                        Format.Transparent);
            _param.Gravity = GravityFlags.Top | GravityFlags.Left;

            if (_advertisingView != null)
            {
                _windowManager.RemoveViewImmediate(_advertisingView);
                mVideoView.Suspend();
            }
            _windowManager.AddView(transparentLayout, _param);
        } 

        public View VideoViewInstance()
        {

            LayoutInflater li = LayoutInflater.From(this);

            _advertisingView = li.Inflate(Resource.Layout.advertising_item, null);

            mVideoView = _advertisingView.FindViewById<VideoView>(Resource.Id.video_view);
            mButton = _advertisingView.FindViewById<Button>(Resource.Id.btnShop); //boton de comprar
            mButton.Visibility = ViewStates.Gone;

            mButton.Click += delegate //resetea al view invisible para los clicks
            {
                DisplayInvisibleLayout();
            };

            //Android.Net.Uri uri = Android.Net.Uri.Parse("android.resource://" + this.PackageName + "/raw/video.3gp");

            mVideoView.SetVideoURI(Android.Net.Uri.Parse(GetVideoUrl.GetUrlBySection(_configuration.GetConfigurationSection()))); //url del video 

           
          //  mVideoView.RequestFocus();
          
            return _advertisingView;
        }         
    }
}