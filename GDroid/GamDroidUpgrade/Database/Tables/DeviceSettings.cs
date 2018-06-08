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

namespace GamDroidUpgrade.Database.Tables
{
    public class DeviceSettings
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        public string UrlWs { get; set; }
        public string ExternalUrl1 { get; set; }
        public string ExternalUrl2 { get; set; }
        public string ClientCode { get; set; }           
    }
}