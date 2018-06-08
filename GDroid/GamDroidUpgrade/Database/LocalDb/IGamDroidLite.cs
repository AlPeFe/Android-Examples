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
using GamDroidUpgrade.Database.Tramas;

namespace GamDroidUpgrade.Database.LocalDb
{
    interface IGamDroidLite
    {
        /// <summary>
        /// Devuelve la configuración del dispositivo
        /// </summary>
        /// <returns></returns>
        DeviceSettings GetDeviceSettings();
        /// <summary>
        /// Modifica la configuración del dispositivo
        /// </summary>
        /// <param name="settings"></param>
        void SetDeviceSettings(DeviceSettings settings);
        /// <summary>
        /// Guarda la posición GPS
        /// </summary>
        /// <param name="location"></param>
        void StoreLocation(Location location);
        /// <summary>
        /// Recoge todas las localizaciones 
        /// </summary>
        /// <returns></returns>
        List<Location> GetAllLocations();
        /// <summary>
        /// Borra todas las posiciones cuando la tabla tenga mas de 500 almacenadas
        /// </summary>
        void DeleteLocations();
        /// <summary>
        /// Devuelve todos los servicios
        /// </summary>
        /// <returns></returns>
        List<Servicio> GetAllServicios();
        /// <summary>
        /// Inserta una colección de servicios
        /// </summary>
        /// <param name="services"></param>
        void InsertServicio(List<Servicio> services);
        /// <summary>
        /// Elimina un servicio
        /// </summary>
        /// <param name="numServicio"></param>
        void DeleteServicio(string numServicio);
        /// <summary>
        /// Modifica el status del servicio
        /// </summary>
        /// <param name="srv"></param>
        void UpdateServicioStatus(Servicio srv);
        /// <summary>
        /// Recoge el servicio por su numsrv
        /// </summary>
        /// <param name="numServicio"></param>
        /// <returns></returns>
        Servicio GetServicio(string numServicio);
        /// <summary>
        /// Inserta trama del servicio para enviar al WS
        /// </summary>
        /// <param name="trama"></param>
        void InsertServicioTrama(ServicioTrama trama);
        /// <summary>
        /// Inserta una trama de mensaje de salida
        /// </summary>
        /// <param name="trama"></param>
        void InsertMessageTrama(MessageTrama trama);
    }
}