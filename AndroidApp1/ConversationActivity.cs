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
    [Activity(Label = "Conversation")]
    public class ConversationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.Conversation);
            //var layout = FindViewById<LinearLayout>(Resource.Layout.Conversation);
            var layout = (LinearLayout)LayoutInflater.Inflate(Resource.Layout.Conversation, null);
            var name = Intent.GetStringExtra("SenderName");

            var t1 = $"{name}: Hello from {name}!";
            var t2 = "Me: Hi WTF you want?";
            var t3 = $"{name}: To meet your momma";
            var text1 = new TextView(this);
            var text2 = new TextView(this);
            var text3 = new TextView(this);
            
            text1.Text = t1;
            text2.Text = t2;
            text3.Text = t3;
            layout.AddView(text1);
            layout.AddView(text2);
            layout.AddView(text3);
            SetContentView(layout);
            // Create your application here
        }
    }
}