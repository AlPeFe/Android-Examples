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
using GamDroidUpgrade.Database.LocalDb;
using GamDroidUpgrade.Adapters;
using Android.Support.V7.App;

namespace GamDroidUpgrade.Screens
{
    [Activity(Label = "ServiceActivity")]
    public class ServiceActivity : AppCompatActivity
    {
        RecyclerView _recyclerView;
        IGamDroidLite _gamdroidLite;

        public ServiceActivity() : this(new GamDroidLite()) { }

        internal ServiceActivity(IGamDroidLite gamdroidLite)
        {
            _gamdroidLite = gamdroidLite;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //SetContentView(Resource.Layout)
            SetContentView(Resource.Layout.ServicioLayout);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.serviceRecyclerView);

            var services = _gamdroidLite.GetAllServicios();

            ServicioAdapter adapter = new ServicioAdapter();
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this)); //????????
            _recyclerView.HasFixedSize = true;
            _recyclerView.SetAdapter(adapter);

            


        }
    }
}