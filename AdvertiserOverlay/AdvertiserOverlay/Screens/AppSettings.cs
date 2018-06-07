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
using AdvertiserOverlay.Model;

namespace AdvertiserOverlay.Screens
{
    [Activity(Label = "Configuración")]
    public class AppSettings : Activity
    {
        EditText mUrl;
        EditText mTimer;
        EditText mShop;
        Button mSaveButton;
        ConfigurationManager _configuration;
        Spinner mDepartament;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
               

                SetContentView(Resource.Layout.settings_activity);
                
                mSaveButton = FindViewById<Button>(Resource.Id.button);
                mTimer = FindViewById<EditText>(Resource.Id.lblTime);
                mShop = FindViewById<EditText>(Resource.Id.lblShop);
                mUrl = FindViewById<EditText>(Resource.Id.lblUrl);
                mDepartament = FindViewById<Spinner>(Resource.Id.spnDepartament);

                var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.sections, Android.Resource.Layout.SimpleSpinnerDropDownItem);
                mDepartament.Adapter = adapter;

                mSaveButton.Click += SaveConfiguration;

            }catch(Exception ex)
            {


            }
        }

        private void SaveConfiguration(object sender, EventArgs e)
        {
            try
            {
                _configuration = new ConfigurationManager();

                _configuration.SetConfiguration(
                    new DisplaySettings {
                        EventTimer = Convert.ToInt32(mTimer.Text),
                        FolderUrl = mUrl.Text,
                        Shop = Convert.ToInt32(mShop.Text),
                        Section = mDepartament.SelectedItem.ToString()
                    });

                StartService(new Android.Content.Intent("DecathlonService.Advertising"));

                Finish();

            }catch(Exception ex)
            {




            }
        }
    }
}