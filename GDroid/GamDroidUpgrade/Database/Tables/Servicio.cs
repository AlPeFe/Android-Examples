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
    public class Servicio
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(9)]
        public string ServiceNumber { get; set; }
        [MaxLength(250)]
        public string Reference { get; set; }
        [MaxLength(250)]
        public string Observations { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DestinationDate { get; set; }
        public bool Companion { get; set; }
        public bool Oxigen { get; set; }
        public int Status { get; set; }
        public string ServiceType { get; set; } //tipus srv
        public string TransferType { get; set; } //motivo traslado
        public string InitialAdress { get; set; }
        public string DestinationAdress { get; set; }
        public string InitialProvince { get; set; }
        public string DestinationProvince { get; set; }
        public string InitialCity { get; set; }
        public string DestinationCity { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Cip { get; set; }
        public string Nass { get; set; }
        public string Dni { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }        
        public bool HasReturnService { get; set; }
        public bool ItsReturnService { get; set; }

    }

    public enum Gender
    {
        MALE,FEMALE
    }
}