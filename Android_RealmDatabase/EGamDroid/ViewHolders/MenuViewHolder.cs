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

namespace EGamDroid.ViewHolders
{
    public class MenuViewHolder : RecyclerView.ViewHolder
    {
        public TextView MenuItemText;
        public ImageView MenuImg;


        public MenuViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            MenuImg = itemView.FindViewById<ImageView>(Resource.Id.menu_img);
            MenuItemText = itemView.FindViewById<TextView>(Resource.Id.menu_caption);
            itemView.Click += (sender, e) => listener(Position);
        }
    }
}