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
using EGamDroid.RealmObjects;
using EGamDroid.ViewHolders;

namespace EGamDroid.Adapter
{
    public class MessagesAdapter : RecyclerView.Adapter
    {

        public List<RMessage> mMessage;

        public MessagesAdapter(List<RMessage> message)
        {
            mMessage = message;
        }

        public override int ItemCount => mMessage.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MessageViewHolder vh = holder as MessageViewHolder;
            vh.Title.Text = mMessage[position].Title;
            vh.Content.Text = mMessage[position].Content;
            vh.Date.Text = mMessage[position].Date.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MessageView , parent, false);

            MessageViewHolder vh = new MessageViewHolder(itemView);

            return vh;
        }
    }
}