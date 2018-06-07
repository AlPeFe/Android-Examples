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
using Android.Media;

namespace AdvertiserOverlay.Model
{
    public class VideoLoop : Java.Lang.Object, Android.Media.MediaPlayer.IOnPreparedListener
    {

        public void OnPrepared(MediaPlayer mp)
        {
            mp.Looping = true;
        }


    }
}