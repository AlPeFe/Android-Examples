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
using Java.Lang;
using Android.Support.V7.Widget;
using EGamDroid.RealmObjects;
using EGamDroid.ViewHolders;

namespace EGamDroid.Adapter
{
    public class MenuAdapter : RecyclerView.Adapter
    {
        public List<RMenu> mMenuItems;
        private Context context;
        public event EventHandler<int> ItemClick;

        public MenuAdapter(Context Context, List<RMenu> MenuItems) {

            mMenuItems = MenuItems;
            context = Context;

        }

        public override int ItemCount => mMenuItems.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MenuViewHolder vh = holder as MenuViewHolder;
            vh.MenuItemText.Text = mMenuItems[position].Caption;
            vh.MenuImg.SetImageResource(Resource.Drawable.Icon);
        }

        private void OnClick(int position)
        {        
            ItemClick(this, position);     
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.menu_item, parent, false);

            MenuViewHolder vh = new MenuViewHolder(itemView, OnClick);

            return vh;
        }
    }
}