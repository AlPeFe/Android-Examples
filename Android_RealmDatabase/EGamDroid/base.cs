using Android.App;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Content;
using System.Threading;




namespace EGamDroid
{
    public class @base : AppCompatActivity
    {
        public Toolbar _toolbar;
        public Intent intent;

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();

            return base.OnOptionsItemSelected(item);
        }
    }
}