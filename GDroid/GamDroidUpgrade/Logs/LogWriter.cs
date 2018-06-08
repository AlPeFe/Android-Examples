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
using System.IO;

namespace GamDroidUpgrade.Logs
{
    public class LogWriter
    {
        public static void WriteException(string method, string screen, string message)
        {

            try
            {
                if(!File.Exists(Constant.LOG_EXCEPTION_PATH))
                {
                    File.Create(Constant.LOG_EXCEPTION_PATH);
                }

                if (File.Exists(Constant.LOG_EXCEPTION_PATH))
                {
                    using (StreamWriter w = File.AppendText(Constant.LOG_PATH))
                    {
                        w.WriteLine("{0} -> [ Method: {1}, Screen: {2}, Message: {3} ]", DateTime.Now, method, screen, message);
                    }
                }
            }
            catch
            {

            }
        }

        public static void Write(string method, string screen, string message)
        {

            if (!File.Exists(Constant.LOG_PATH))
            {
                File.Create(Constant.LOG_PATH);
            }

            if (File.Exists(Constant.LOG_PATH))
            {
                using (StreamWriter w = File.AppendText(Constant.LOG_PATH))
                {
                    w.WriteLine("{0} -> [ Method: {1}, Screen: {2}, Message: {3} ]", DateTime.Now, method, screen, message);
                }            
            }
        }
    }
}