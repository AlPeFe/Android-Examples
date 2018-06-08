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

namespace GamDroidUpgrade.ViewHolders
{
    public class StatusSrv
    {
        public string Description { get; private set; }

        public int Status { get; private set; }

        public Android.Graphics.Color Colour { get; private set; } 

        public static StatusSrv GetStatusSrv(int status)
        {
            StatusSrv statusSrv = new StatusSrv();

            statusSrv.Colour = statusSrv.SetStatusColor(status);
            statusSrv.Description =  statusSrv.SetDescription(status);
            statusSrv.Status = status;

            return statusSrv;
        }

        public string SetDescription(int status)
        {
            string description = "";

            switch (status)
            {
                case 700:
                    description = "CONFIRMA";
                    break;
                case 705:
                    description = "ACTIVACION";
                    break;
                case 710:
                    description = "LLEGA ORIGEN";
                    break;
                case 715:
                    description = "EVACUACION";
                    break;
                case 720:
                    description = "LLEGA DESTINO";
                    break;
                case 725:
                    description = "TRANSFER";
                    break;
                case 730:
                    description = "LIBRE";
                    break;
                case 735:
                    description = "FINAL";
                    break;
                case 740:
                    description = "RECIBIDO";
                    break;
                default:
                    description = "";
                    break;
            }

            return description;
        }

        public Android.Graphics.Color SetStatusColor(int status)
        {
            Android.Graphics.Color color = new Android.Graphics.Color();

            switch (status)
            {
                case 700:
                    color = Android.Graphics.Color.Green;
                    break;
                case 705:
                    color = Android.Graphics.Color.LightGreen;
                    break;
                case 710:
                    color = Android.Graphics.Color.Yellow;
                    break;
                case 715:
                    color = Android.Graphics.Color.Orange;
                    break;
                case 720:
                    color = Android.Graphics.Color.OrangeRed;
                    break;
                case 725:
                    color = Android.Graphics.Color.DarkOrange;
                    break;
                case 730:
                    color = Android.Graphics.Color.Brown;
                    break;
                case 735:
                    color = Android.Graphics.Color.RosyBrown;
                    break;
                case 740:
                    color = Android.Graphics.Color.Green;
                    break;
                default:
                    color = Android.Graphics.Color.BurlyWood;
                    break;
            }

            return color;
        }
    }
}