using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using GamDroidUpgrade.Database.Tables;
using GamDroidUpgrade.Database.LocalDb;
using GamDroidUpgrade.ViewHolders;
using GamDroidUpgrade.Screens;
using GamDroidUpgrade.Database.Tramas;

namespace GamDroidUpgrade.Adapters
{
    public class ServicioAdapter : RecyclerView.Adapter
    {
        private List<Servicio> _servicios;
        private IGamDroidLite _gamDroidLite;
        
        public override int ItemCount => _servicios.Count;

        public ServicioAdapter() : this(new GamDroidLite()) { }

        internal ServicioAdapter(IGamDroidLite gamDroidLite)
        {
            _gamDroidLite = gamDroidLite;
            _servicios = _gamDroidLite.GetAllServicios().OrderBy(x => x.StartDate).ToList();
        }
        
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ServicioViewHolder srvViewHolder = holder as ServicioViewHolder;

            Context context = srvViewHolder.BtnDetail.Context; // da igual de que elemento sea el context porque todo viene del mismo sitio, pasarlo por el constructor no es correcto segun la documentacion de Android, esta es la forma mas eficiente
          
            var srvStatus = StatusSrv.GetStatusSrv(_servicios[position].Status);
            
            srvViewHolder.Status.Text = srvStatus.Description;

            if (!srvViewHolder.Status.HasOnClickListeners)
            {
                srvViewHolder.Status.Click += (sender, args) => { NextStatus(srvViewHolder.AdapterPosition); };
            }

            srvViewHolder.Status.SetBackgroundColor(srvStatus.Colour);

            srvViewHolder.StartDate.Text = _servicios[position].StartDate?.ToString();          

            srvViewHolder.PatientInfo.Text = _servicios[position].Name + " " + _servicios[position].Surname;

            srvViewHolder.DestinationAdress.Text = GetServicioAdressByStatus(_servicios[position].Status, position);

            if (!srvViewHolder.BtnDetail.HasOnClickListeners)
            {
                srvViewHolder.BtnDetail.Click += (sender, args) => { BtnDetailClick(srvViewHolder.AdapterPosition, context); };
            }

            if (!srvViewHolder.BtnCancel.HasOnClickListeners)
            {
                srvViewHolder.BtnCancel.Click += (sender, args) => { BtnCancelClick(srvViewHolder.AdapterPosition, context); };
            }

            if (!srvViewHolder.BtnNavigate.HasOnClickListeners)
            {
                srvViewHolder.BtnNavigate.Click += (sender, args) => { BtnNavigateClick(srvViewHolder.AdapterPosition, context); };
            }
        }

        private string GetServicioAdressByStatus(int status, int position)
        {
            string adress = "";

            if((status <= 715) || (status == 740) )
            {
                adress = _servicios[position].InitialAdress + ", " + _servicios[position].InitialCity;

            }else if((status >= 715 && status != 740))
            {
                adress = _servicios[position].DestinationAdress + ", " + _servicios[position].DestinationCity;
            }
            
            return adress;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_servicio, parent, false);
            ServicioViewHolder vh = new ServicioViewHolder(itemView, OnClick);

            return vh;
        }

        private void BtnDetailClick(int position, Context context)
        {
            Intent i = new Intent(context, typeof(DetailActivity));
            i.PutExtra("NumSrv", _servicios[position].ServiceNumber);
            context.StartActivity(i);
        }

        private void NextStatus(int position)
        {
         
            var servicio = _servicios[position];
            servicio.Status = servicio.Status + 5;
            var trama = GenerateTrama(servicio);

            if (servicio.Status != 735) // si next status != fin faltaria generar trama tambien
            {             
                _gamDroidLite.UpdateServicioStatus(servicio);
                this.NotifyItemChanged(position);
            }
            else // si siguiente status es el final se elimina, generar ultima trama
            {    
                _gamDroidLite.DeleteServicio(servicio.ServiceNumber);
                _servicios.Remove(servicio);
                this.NotifyItemRemoved(position);              
            }

            _gamDroidLite.InsertServicioTrama(trama);

            //funcion genera trama                   
        }

        private void BtnCancelClick(int position, Context context)
        {

            AlertDialog.Builder builder = new AlertDialog.Builder(context, Resource.Style.CustomAlertDialogStyle);
            builder.SetSingleChoiceItems(new string[]{ "04","06","12","45"}, -1,(s, e)=> { } );
            //builder.SetMessage("¿Seguro que quiere anular este servicio? Se enviará a coordinación la petición de anulación");
            builder.SetTitle("Anular Servicio");
            builder.SetPositiveButton("Anular", (sender, args) => 
            {
                _gamDroidLite.InsertMessageTrama(
                    new MessageTrama
                    {
                        AmbulanceCode = "125",
                        Content = "Anulado servicio " + _servicios[position].ServiceNumber + " por motivo ",
                        Date = DateTime.Now,
                        Key = "040"
                    });           
                //_gamDroidLite.InsertServicioTrama(_)
                _gamDroidLite.DeleteServicio(_servicios[position].ServiceNumber);
                _servicios.Remove(_servicios[position]);
                this.NotifyItemRemoved(position);
            });
            builder.SetNegativeButton("Cancelar", (Android.Content.IDialogInterfaceOnClickListener)null);
            builder.Create().Show();
            
        }

        private void BtnNavigateClick(int position, Context context)
        {
            string address = GetServicioAdressByStatus(_servicios[position].Status, position);

            string uri = string.Format("http://maps.google.com/maps?daddr={0}&", address);

            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(uri));

            context.StartActivity(intent);
        }

        private ServicioTrama GenerateTrama(Servicio servicio)
        {
            return new ServicioTrama
            {
                ServiceNumber = servicio.ServiceNumber,
                Date = DateTime.Now,
                Status = servicio.Status,
                Latitude = 2,
                Longitude = 2,
                AmbulanceCode = "125"
            };
        }

        void OnClick(int position)
        {
            

        }      
    }
}