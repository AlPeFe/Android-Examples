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
using GamDroidUpgrade.Database.LocalDb;
using GamDroidUpgrade.Database;
using GamDroidUpgrade.Database.Tables;
using System.IO;

namespace GamDroidUpgrade.Utils
{
    public class Auto // esta clase es para llamar la primera vez unicamente OJO SOLO UNA VEZ !!!
    {
        IGamDroidLite _GamDroidlite;

        public Auto() : this(new GamDroidLite()){ }

        internal Auto(IGamDroidLite gamDroidLite)
        {
            _GamDroidlite = gamDroidLite;
        }

        public static void Boot()
        {
            try
            {
                GamDroidDb db = new GamDroidDb();
                db.SetUp(); //genera las tablas 

                new Auto()._GamDroidlite.SetDeviceSettings(GetLocalSettings()); // para llamar a la propiedad no estatica sino siempre es nula la variable 
                new Auto()._GamDroidlite.InsertServicio(new List<Servicio> {
                new Servicio {ServiceNumber = "000000001", Name = "Jordi", Surname = "Mateo", Age = 23, StartDate = new DateTime(2018,01,01,21,08,00),Observations="Tiene que llevar oxigeno sino la apechusca", DestinationAdress = "Hospital Germans Trias i Pujol", Status = 715, Gender = Gender.MALE, Dni = "48224946H", BirthDate = new DateTime(1994, 04 ,08), Cip = "0114524555", Nass = "A454545646", PhoneNumber = "678945614" },
                new Servicio {ServiceNumber = "000000002" , Name = "Alex", Surname = "Perez", Age = 23, StartDate = new DateTime(2018,01,01,17,15,00), DestinationAdress = "Hospital Vall d'Hebron ", Status = 720 },
                });

            }
            catch(Exception ex)
            {

            }
        }

        private static DeviceSettings GetLocalSettings() // si encuentra config GamDroid configura la aplicación con esos valores
        {

            DeviceSettings settings = new DeviceSettings();
            var file = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
            string directory = Path.Combine(file.AbsolutePath, "ConfigClient/");
            string path = Path.Combine(directory, "ficheroConfigCliente.txt");

            if (Directory.Exists(directory))
            {
                if (System.IO.File.Exists(path))
                {
                    string[] rpta = new string[38];

                    using (var reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
                    {
                          //esto contiene el config, el array con todo, se ha cogido el código de GAMDROID ANTIGUO
                        string line = "";
                        int i = 0;
                        while ((line = reader.ReadLine()) != null)
                        {                      
                            string[] split = line.Split(new Char[] { '=' });
                            int y = 1;
                            foreach (string s in split)
                            {
                                if (y == 2)
                                {
                                    rpta[i] = s;
                                    i++;
                                }
                                y++;
                            }                          
                        }
                    }

                    //values 5-> Cliente, 6-> URL, 29-> VHI  ||| FALTA AÑADIR EL RESTO

                    settings.UrlWs = rpta[6];
                    settings.ClientCode = rpta[5];
      
                    
                    //faltaria borrar el archivo despues de configurar con sus datos, para que no lo intente de nuevo 
                }                 
            }

            return settings;
        }

    }
}