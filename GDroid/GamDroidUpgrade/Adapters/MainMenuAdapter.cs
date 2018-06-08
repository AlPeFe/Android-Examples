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
using GamDroidUpgrade.Utils;
using GamDroidUpgrade.ViewHolders;

namespace GamDroidUpgrade.Adapters
{
    public class MainMenuAdapter : RecyclerView.Adapter
    {

        private List<MenuItems> _items = new List<MenuItems>();

        private Context _context;

        public override int ItemCount => _items.Count;

        public MainMenuAdapter(List<MenuItems> items, Context context)
        {
            _items = items;
            _context = context;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MenuItemsViewHolder MsViewHolder = holder as MenuItemsViewHolder;
            MsViewHolder.textView.Text = _items[position].Caption;//_items[position].Caption;
            MsViewHolder.imageView.SetImageResource(_items[position].Icon);
            //MsViewHolder.imageView.SetImageDrawable(Android.Support.V7.Content.Res.AppCompatResources.GetDrawable(Application.Context, Resource.Drawable.ic_weekend_black_24dp));
        } 

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.item_menu, parent, false);
            MenuItemsViewHolder vh = new MenuItemsViewHolder(itemView, OnClick); //Esto esta bien
            return vh;
        }

        void OnClick(int position)
        {
            // ItemClick(this, position);
            _context.StartActivity(_items[position].Intent);
        }
    }
}