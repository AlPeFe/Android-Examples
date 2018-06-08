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
using SQLite;

namespace AndroidTest.Database.Tables
{
    public class Configuration
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string url { get; set; }
    }
}