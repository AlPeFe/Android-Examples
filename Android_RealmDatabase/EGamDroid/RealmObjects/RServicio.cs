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

namespace EGamDroid.RealmObjects
{
    public class RServicio : RealmObject
    {
        public string Title { get; set; }

        public string Content { get; set; }

    }
}