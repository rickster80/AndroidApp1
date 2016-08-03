using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidApp1
{
    [Activity(Label = "AndroidApp1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.LoginBtn);
            button.Click += LoginClick;
        }

        public void LoginClick(object obj, EventArgs args)
        {
            var email = FindViewById<TextView>(Resource.Id.Username).Text;
            var pw = FindViewById<TextView>(Resource.Id.Password).Text;
            Button button = FindViewById<Button>(Resource.Id.LoginBtn);

            if(email == "" || pw == "")
            {
                var error = FindViewById<TextView>(Resource.Id.ErrorMessage).Visibility = ViewStates.Visible;
                return;
            }

            var next = new Intent(this, typeof(MessagesActivity));
            StartActivity(next);
        }
    }
}

