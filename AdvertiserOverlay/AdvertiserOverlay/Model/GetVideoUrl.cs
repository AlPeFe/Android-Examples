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

namespace AdvertiserOverlay.Model
{
    public class GetVideoUrl
    {
         private static string Fitness =   @"http://6456.4564.56/50085/Videos/Fitness/video.mp4"; 

        private static string Musculacion = @"http://4564.5645.6456:50080/50085/Videos/Musculacion/video.mp4"; 

        private static string Yoga = @"http://45.6456546.5464:50080/50085/Videos/Yoga/video.mp4"; 


        public static string GetUrlBySection(string section)
        {
            var url = "";

            switch(section)
            {
                case "Fitness, Cardio, Pilates":
                    url = Fitness;
                    break;
                case "Musculación, Cross Training":
                    url = Musculacion;
                    break;
                case "Yoga, Danza y Gimnasia":
                    url = Yoga;
                    break;
                default:
                    url = Yoga;
                    break;
            }
        
            return url;
        }
    }
}