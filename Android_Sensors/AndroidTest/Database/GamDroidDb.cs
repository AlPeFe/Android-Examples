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
using AndroidTest.Database.Tables;
using System.IO;



namespace AndroidTest.Database
{
    public class GamDroidDb : SQLiteConnection
    {
        public GamDroidDb() : base(DbPath.path)
        {
            CreateTable<Configuration>();
            CreateTable<Location>();
        }
    } 

    class DbPath
    {
        public static string path => Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), Guid.NewGuid() + ".sqlite");
    }
}