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
    public class Message
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public string AmbulanceCode { get; set; }
        public string Key { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(250)]
        public string Content { get; set; }

    }
}