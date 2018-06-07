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
using Realms;

namespace AdvertiserOverlay.Model
{
    public class DisplaySettings : RealmObject
    {
        public int id { get; set; }

        public int EventTimer { get; set; }

        public string FolderUrl { get; set; }

        public int Shop { get; set; }

        public string Section { get; set; }
    }
}