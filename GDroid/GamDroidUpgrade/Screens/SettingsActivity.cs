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
using Android.Support.V4;
using GamDroidUpgrade.Fragments;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace GamDroidUpgrade.Screens
{
    [Activity(Label = "SettingsActivity")]
    public class SettingsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SettingsLayout);
            //var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);
            var button = FindViewById<Button>(Resource.Id.but_save);

            Android.Support.V4.App.Fragment preferenceFragment = new SettingsFragment();
            Android.Support.V4.App.FragmentTransaction ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.pref_container, preferenceFragment);
            ft.Commit(); 
            // Create your application here
        }
    }
}