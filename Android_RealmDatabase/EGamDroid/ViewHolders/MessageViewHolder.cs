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
    public class MessageViewHolder : RecyclerView.ViewHolder
    {

        public TextView Title { get; set; }
        public TextView Content { get; set; }
        public TextView Date { get; set; }

        public MessageViewHolder(View itemView) : base (itemView)
        {

            Title = ItemView.FindViewById<TextView>(Resource.Id.msgTitle);
            Content = ItemView.FindViewById<TextView>(Resource.Id.msgContent);
            Date = ItemView.FindViewById<TextView>(Resource.Id.msgData);

        }
    }
}