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
using Android.Support.V7.App;
using GamDroidUpgrade.Database.LocalDb;

namespace GamDroidUpgrade.Screens
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : AppCompatActivity
    {

        #region paciente variables

        TextView _name;
        TextView _birthDate;
        TextView _dni;
        TextView _gender;
        TextView _nass;
        TextView _cip;
        TextView _phoneNumber1;
        TextView _phoneNumber2;
        TextView _phoneNumber3;
        TextView _homeAdress;
        TextView _obs;
        TextView _serviceNumber;
        TextView _destinationAdress;
        TextView _originAddress;
        TextView _oxigen;
        TextView _oxigenConcentration;

        #endregion

        private IGamDroidLite _gamDroidLite;

        public DetailActivity() : this(new GamDroidLite()) { }

        internal DetailActivity(IGamDroidLite gamDroidLite)
        {
            _gamDroidLite = gamDroidLite;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DetailLayout);

            var serviceNumber = Intent.GetStringExtra("NumSrv");

            var servicio = _gamDroidLite.GetServicio(serviceNumber);

            if (servicio != null) {

                _name = FindViewById<TextView>(Resource.Id.txtName);
                _birthDate = FindViewById<TextView>(Resource.Id.txtBirthDate);
                _dni = FindViewById<TextView>(Resource.Id.txtDni);
                _nass = FindViewById<TextView>(Resource.Id.txtNass);
                _cip = FindViewById<TextView>(Resource.Id.txtCip);
                _phoneNumber1 = FindViewById<TextView>(Resource.Id.txtPhoneNumber);
                _phoneNumber2 = FindViewById<TextView>(Resource.Id.txtPhoneNumber2);
                _phoneNumber3 = FindViewById<TextView>(Resource.Id.txtPhoneNumber3);
                _homeAdress = FindViewById<TextView>(Resource.Id.txtOAdress);
                _gender = FindViewById<TextView>(Resource.Id.txtSexo);
                _obs = FindViewById<TextView>(Resource.Id.txtObs);
                _serviceNumber = FindViewById<TextView>(Resource.Id.txtNumSrv);
                _destinationAdress = FindViewById<TextView>(Resource.Id.txtDAdress);
                _originAddress = FindViewById<TextView>(Resource.Id.txtOAdress);
                _oxigen = FindViewById<TextView>(Resource.Id.txtOxigen);
                _oxigenConcentration = FindViewById<TextView>(Resource.Id.txtOxigenConcentracion);

                _name.Text = servicio.Name + " " + servicio.Surname;
                _birthDate.Text = servicio.BirthDate?.ToString().Trim();
                _dni.Text = servicio.Dni;
                _nass.Text = servicio.Nass;
                _cip.Text = servicio.Cip;
                _phoneNumber1.Text = servicio.PhoneNumber;
                _phoneNumber2.Text = servicio.PhoneNumber;
                _phoneNumber3.Text = servicio.PhoneNumber;
                _gender.Text = servicio.Gender.ToString();
                _obs.Text = servicio.Observations;
                _serviceNumber.Text = servicio.ServiceNumber;
                _originAddress.Text = "ORIGEN : " + servicio.InitialAdress + " " + servicio.InitialCity;
                _destinationAdress.Text = "DESTINO : " + servicio.DestinationAdress + " " + servicio.DestinationCity;








            }
        }
    }
}