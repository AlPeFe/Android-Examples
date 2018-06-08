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

namespace GamDroidUpgrade.ViewHolders
{
    class MenuItemsViewHolder : RecyclerView.ViewHolder
    {
        public TextView textView { get; set; }
        public ImageView imageView { get; set; }
        public RelativeLayout relativeLayout { get; set; }

        public MenuItemsViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            textView = itemView.FindViewById<TextView>(Resource.Id.textView);
            imageView = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            relativeLayout = itemView.FindViewById<RelativeLayout>(Resource.Id.relativeLayout);
            itemView.Click += (sender, e) => listener(AdapterPosition);
        }

    }
}