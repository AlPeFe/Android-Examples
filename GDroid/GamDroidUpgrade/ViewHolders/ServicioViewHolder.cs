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
using Android.Support.V7.Widget;
using GamDroidUpgrade.Database.Tables;

namespace GamDroidUpgrade.ViewHolders
{
    public class ServicioViewHolder : RecyclerView.ViewHolder
    {
        public TextView Status { get; set; }
        public TextView StartDate { get; set; }
        public TextView PatientInfo { get; set; }
        public TextView DestinationAdress { get; set; }
        public AppCompatImageView BtnDetail { get; set; }
        public AppCompatImageView BtnCancel { get; set; }
        public AppCompatImageView BtnNavigate { get; set; }

        public ServicioViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            Status = itemView.FindViewById<TextView>(Resource.Id.transStatus);          
            StartDate = itemView.FindViewById<TextView>(Resource.Id.transDate);
            PatientInfo = itemView.FindViewById<TextView>(Resource.Id.transContentPatient);
            DestinationAdress = itemView.FindViewById<TextView>(Resource.Id.transContentDireccion);
            BtnDetail = ItemView.FindViewById<AppCompatImageView>(Resource.Id.transBtnDescription);
            BtnCancel = ItemView.FindViewById<AppCompatImageView>(Resource.Id.transBtnCancel);
            BtnNavigate = ItemView.FindViewById<AppCompatImageView>(Resource.Id.transBtnMaps);           
            itemView.Click += (sender, e) => listener(AdapterPosition);
        }

      

    }
}