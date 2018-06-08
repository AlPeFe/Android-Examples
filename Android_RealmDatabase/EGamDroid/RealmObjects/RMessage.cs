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

namespace EGamDroid.RealmObjects
{
    public class RMessage
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}