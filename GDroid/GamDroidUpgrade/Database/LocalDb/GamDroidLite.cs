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
using GamDroidUpgrade.Database.Tables;
using Message = GamDroidUpgrade.Database.Tables.Message;
using GamDroidUpgrade.Database.Tramas;

namespace GamDroidUpgrade.Database.LocalDb
{
    class GamDroidLite : IGamDroidLite
    {
        

        #region CONFIG

        public DeviceSettings GetDeviceSettings()
        {
            GamDroidDb db = new GamDroidDb();

            DeviceSettings settings = new DeviceSettings();

            if (db != null)
            {
                settings = db.Table<DeviceSettings>().FirstOrDefault();
            }

            return settings;
        }

        public void SetDeviceSettings(DeviceSettings settings)
        {
            GamDroidDb db = new GamDroidDb();

            if (db != null)
            {
                db.Insert(settings);
            }

        }

        #endregion 

        #region GPS

        public void StoreLocation(Location location)
        {
            GamDroidDb db = new GamDroidDb();

            if(db != null)
            {
                db.Insert(location);
            }
        }

        public List<Location> GetAllLocations()
        {
            List<Location> posiciones = new List<Location>();

            GamDroidDb db = new GamDroidDb();

            if (db != null)
            {
                posiciones = db.Table<Location>().ToList();
            }
            return posiciones;
        }

        public void DeleteLocations()
        {
            GamDroidDb db = new GamDroidDb();
            
            if (db != null)
            {
                if(db.Table<Location>().Count() > 500)
                {
                    db.DeleteAll<Location>();
                }
            }         
        }

        #endregion

        #region SERVICIOS 

        public List<Servicio> GetAllServicios()
        {
            List<Servicio> services = new List<Servicio>();

            GamDroidDb db = new GamDroidDb();

            if (db != null)
            {
                services = db.Table<Servicio>().ToList();
            }

            return services;     
        }

        public void InsertServicio(List<Servicio> services)
        {
            GamDroidDb db = new GamDroidDb();

            if(db != null)
            {
                db.InsertAll(services);
            }
        }

        public void DeleteServicio(string numServicio)
        {
            GamDroidDb db = new GamDroidDb();

            if (db != null)
            {
                db.Delete<Servicio>(numServicio);
            }

        }

        public void UpdateServicioStatus(Servicio srv)
        {
            GamDroidDb db = new GamDroidDb();

            if(db != null)
            {
                db.Update(srv);
            }
        }

        public Servicio GetServicio(string numServicio)
        {
            var service = new Servicio();

            GamDroidDb db = new GamDroidDb();

            if (db != null)
            {
                service = db.Table<Servicio>().Where(x=> x.ServiceNumber == numServicio).FirstOrDefault();
            }

            return service;
        }

        public void InsertServicioTrama(ServicioTrama trama)
        {
            GamDroidDb db = new GamDroidDb();

            if (db != null)
            {
                db.Insert(trama);
            }
        }
      
        #endregion

        #region MENSAJES

        public List<Message> GetAllMessages()
        {
            List<Message> mensajes = new List<Message>();

            GamDroidDb db = new GamDroidDb();

            if (db != null)
            {
                mensajes = db.Table<Message>().ToList();
            }
            return mensajes;
        }

        public void InsertMessage(Message message) // se hace uno a uno y no en una colecciçon porque realment no se mandan tantos mensajes de golpe, de esta forma la conexión se abre y se cierra individualmente, por si se va la conexion y se manda una lista no llegaria ninguno
        {
            GamDroidDb db = new GamDroidDb();

            if (db != null)
            {
                db.Insert(message);              
            }
        }

        public void InsertMessageTrama(MessageTrama trama)
        {
            GamDroidDb db = new GamDroidDb();

            if (db != null)
            {
                db.Insert(trama);
            }

        }

        public void MessageServicioCancelation()
        {


        }

        #endregion

        #region extra (gastos,paradas)

        



        #endregion
    }
}