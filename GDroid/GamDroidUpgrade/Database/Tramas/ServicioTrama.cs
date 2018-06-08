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

namespace GamDroidUpgrade.Database.Tramas
{
    public class ServicioTrama
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public string ServiceNumber { get; set; }
        public string AmbulanceCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        
    }
}