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

namespace AndroidApp1
{
    public class SecureBaseActivity : Activity
    {
        private void DoLogout()
        {
            var logout = new Intent(this, typeof(MainActivity));
            StartActivity(logout);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.logout:
                    DoLogout();
                    break;
                default:
                    break;

            }
            return base.OnOptionsItemSelected(item);
        }
    }
    public class SecureBaseListActivity : ListActivity
    {
        private void DoLogout()
        {
            var logout = new Intent(this, typeof(MainActivity));
            StartActivity(logout);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.logout:
                    DoLogout();
                    break;
                default:
                    break;

            }
            return base.OnOptionsItemSelected(item);
        }
    }
}