using Android.App;
using Android.Widget;
using Android.OS;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using EGamDroid.Adapter;
using Android.Support.V7.Widget;
using EGamDroid.RealmObjects;
using System.Collections.Generic;
using Android.Content;

namespace EGamDroid
{
    [Activity(Label = "EGamDroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : @base
    {
        private GridLayoutManager layout;
        private ImageView imgView;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
        
            SetSupportActionBar(_toolbar);

            imgView = FindViewById<ImageView>(Resource.Id.btnTest);
            imgView.Click += delegate
            {

                StartActivity(new Intent(this, typeof(Screens.Messages)));

            };

       
            if (this.Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                layout = new GridLayoutManager(this, 4);
            }
            else
            {
                layout = new GridLayoutManager(this, 2);
            }
                    
            List<RMenu> MenuItems = new List<RMenu> {

                new RMenu{ Caption = "item" },
                new RMenu{ Caption = "item" },
                new RMenu{ Caption = "item" },
                new RMenu{ Caption = "item" },
                new RMenu{ Caption = "item" },
                new RMenu{ Caption = "item" },
                new RMenu{ Caption = "item" },
                new RMenu{ Caption = "item" }
            };

            RecyclerView rView = (RecyclerView)FindViewById(Resource.Id.recycler_view);
            rView.HasFixedSize = true;
            rView.SetLayoutManager(layout);
           
            MenuAdapter mAdapter = new MenuAdapter(this, MenuItems);
            rView.SetAdapter(mAdapter);
            mAdapter.ItemClick += OnItemClick;           
        }

        public void OnItemClick(object sender, int position)
        {

            //switch de las posiciones conforme sus activities

          
        }
    }
}

