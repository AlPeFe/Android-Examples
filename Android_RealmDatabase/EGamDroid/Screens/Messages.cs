using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Widget;
using Android.OS;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using EGamDroid.Adapter;
using Android.Support.V7.Widget;
using EGamDroid.RealmObjects;

using Android.Content;

namespace EGamDroid.Screens
{
    [Activity(Label = "Messages")]
    public class Messages : @base
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Messages);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(_toolbar);

            List<RMessage> Messages = new List<RMessage>
            {
                new RMessage{ Content = "prueba", Date = DateTime.Now, Title = "Testing Adapter"},
                new RMessage{ Content = "prueba2", Date = DateTime.Now, Title = "Testing Adapter"},
                new RMessage{ Content = "prueba3", Date = DateTime.Now, Title = "Testing Adapter"},
                new RMessage{ Content = "prueba4", Date = DateTime.Now, Title = "Testing Adapter"},
                new RMessage{ Content = "prueba5", Date = DateTime.Now, Title = "Testing Adapter"}
            };

            RecyclerView rView = (RecyclerView)FindViewById(Resource.Id.recycler_view2);
            rView.HasFixedSize = true;

            MessagesAdapter mAdapter = new MessagesAdapter(Messages);
            rView.SetAdapter(mAdapter);
        }
    }
}