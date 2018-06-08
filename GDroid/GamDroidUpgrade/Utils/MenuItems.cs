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
using GamDroidUpgrade.Screens;

namespace GamDroidUpgrade.Utils
{
    public class MenuItems
    {
        public int Id { get; set; }

        public int Icon { get; set; }

        public string Caption { get; set; }

        public Type Intent { get; set; }

        public List<MenuItems> GetMenuItems(string clientCode) //devuelve la configuración de menu basada en el cliente
        {     
            var menuItems = ItemsCollecion();

            var excludedItems = ClientMenuSettings(clientCode);

            menuItems = menuItems.Where(x => !excludedItems.Any(e => x.Id.Equals(e))).ToList();

            return menuItems;
        } 

        private List<MenuItems> ItemsCollecion()
        {
            List<MenuItems> items = new List<MenuItems>()
            {
                new MenuItems{
                    Id = 1,
                    Caption = "Development",
                    Intent = typeof(MessageActivity),
                    Icon = Resource.Drawable.ic_build_black_36dp
                },
                new MenuItems{
                    Id = 2,
                    Caption = "Servicios",
                    Intent = typeof(ServiceActivity),
                    Icon = Resource.Drawable.ic_build_black_36dp
                },
                new MenuItems{
                    Id = 3,
                    Caption = "Mensajes",
                    Intent = typeof(MessageActivity),
                    Icon = Resource.Drawable.ic_build_black_36dp
                },
                new MenuItems{
                    Id = 4,
                    Caption = "Inicio de Turno",
                    Intent = typeof(MessageActivity),
                    Icon = Resource.Drawable.ic_build_black_36dp
                },
                new MenuItems{
                    Id = 5,
                    Caption = "Configuración",
                    Intent = typeof(MessageActivity),
                    Icon = Resource.Drawable.ic_build_black_36dp
                },             
            };

            return items;
        }  

        private List<int> ClientMenuSettings(string clientCode)
        {
            List<int> idItems = new List<int>();

            switch(clientCode)
            {
                case "EGAR":
                    idItems.Add(1);             
                    break;
                case "TOMA":
                    idItems.Add(1);              
                    break;
                case "CATA":
                    idItems.Add(1);             
                    break;
                default:
                    idItems.Add(1);
                   
                    break;
            }

            return idItems;
        }
    }
}