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
    public class Shift
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public char Type { get; set; } //entrada o salida
        public DateTime Date { get; set; }
        public char Job { get; set; } //ayudante, chofer, medico, etc..
    }
}