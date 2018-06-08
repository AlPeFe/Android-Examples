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
using System.IO;
using GamDroidUpgrade.Database.Tables;
using GamDroidUpgrade.Database.Tramas;

namespace GamDroidUpgrade.Database
{
    public class GamDroidDb : SQLiteConnection //la herencia es necesaria para pasar el argumento del path
    {
        public GamDroidDb() : base(DbPath.path) // con el constructor asi de esta forma ya no hay que pasar el parametro del path pero sigue siendo accesible desde la clase externa por si se necesita para otra cosa
        {

        }

        public void SetUp() //no lo coloco en el constructor porque no quiero que se ejecute todo el rato, mejor aqui asi de esta forma solo se llama al SetUp cuando inicie la aplicación
        {
            CreateTable<DeviceSettings>(); //crea las tablas, si se han modificado guarda los datos y los coloca en las nuevas 
            CreateTable<Location>();
            CreateTable<GamDroidUpgrade.Database.Tables.Message>();
            CreateTable<Servicio>();
            CreateTable<ServicioTrama>();
            CreateTable<MessageTrama>();
        }
    }

    class DbPath
    {
        public static string path => Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GamDroid.sqlite"); //path del sqlite en local, de momento solo GET por si acaso, no creo que deba ser set
    }
}