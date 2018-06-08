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
using GamDroidUpgrade.Utils;
using Android.Support.V7.Widget;
using GamDroidUpgrade.Database.LocalDb;
using GamDroidUpgrade.Adapters;

namespace GamDroidUpgrade.Screens
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : AppCompatActivity
    {
        RecyclerView _recyclerView;
        IGamDroidLite _GamDroidLite;

        public MenuActivity() : this(new GamDroidLite()) { }

        internal MenuActivity(IGamDroidLite gamDroidLite)
        {
            _GamDroidLite = gamDroidLite;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MenuItems menuItems = new MenuItems();

            SetContentView(Resource.Layout.MenuLayout);
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            var icons = menuItems.GetMenuItems("EGAR");//_GamDroidLite.GetDeviceSettings().ClientCode);

            MainMenuAdapter adapter = new MainMenuAdapter(icons, this);
            _recyclerView.SetAdapter(adapter);

            GridLayoutManager manager = new GridLayoutManager(this, 3, GridLayoutManager.Vertical, false);
            _recyclerView.SetLayoutManager(manager);

        }

      
    }
}