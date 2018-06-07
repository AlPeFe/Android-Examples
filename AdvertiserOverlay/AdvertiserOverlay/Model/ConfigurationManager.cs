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
using Realms;

namespace AdvertiserOverlay.Model
{
    class ConfigurationManager
    {
        public int Timer
        {
            get
            {
                return GetTimer();
            }
        }

        public string Url
        {
            get
            {
                return GetUrl();
            }
        }

        private Realm Instance()
        {
            var realm = Realm.GetInstance();
            return realm;

        }

        public DisplaySettings GetConfiguration()
        {                         
            return Instance().All<DisplaySettings>().FirstOrDefault();
        }

        public void SetConfiguration(DisplaySettings settings)
        {
            try
            {
                settings.id = 1;

                Instance().Write(() =>
                {
                    Instance().Add(
                        new DisplaySettings
                        {
                            id = settings.id,
                            Section = settings.Section,
                            Shop = settings.Shop,
                            EventTimer = settings.EventTimer,
                            FolderUrl = settings.FolderUrl
                        });

                });

            }
            catch
            {


            }
        }

        public string GetConfigurationSection()
        {
            string section = "";

            try
            {
                var s = Instance().All<DisplaySettings>().FirstOrDefault();

                if(s != null)
                {
                    section = s.Section;
                }
            }
            catch(Exception ex)
            {


            }

            return section;
        }

        private int GetTimer()
        {
            return GetConfiguration().EventTimer;
        }

        private string GetUrl()
        {
            return GetConfiguration().FolderUrl;
        }
    }
}