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
    public class ConversationActivity : SecureBaseActivity
    {
        private string _name;
        private List<string> _messages;
        private void renderView()
        {
            var layout = (LinearLayout)LayoutInflater.Inflate(Resource.Layout.Conversation, null);
            foreach (var m in _messages)
            {
                var textView = new TextView(this);
                textView.Text = m;
                layout.AddView(textView);
            }
            SetContentView(layout);
            var btn = FindViewById<Button>(Resource.Id.sendbutton);
            btn.Click += delegate {
                var message = (EditText)FindViewById(Resource.Id.newmessage);
                var text = $"ME: {message.Text}";
                TextView tv = new TextView(this);
                tv.Text = text;
                layout.AddView(tv);
            };
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _name = Intent.GetStringExtra("SenderName");
            _messages = new List<string>()
            {
                $"{_name}: Hello from {_name}!",
                "Me: Hi WTF you want?",
                $"{_name}: To meet your momma"
            };
            renderView();
            


        }
        public void SendMessageClick(object obj, EventArgs args)
        {
            
            var message = (EditText)FindViewById(Resource.Id.newmessage);
            var text = message.Text;
            _messages.Add($"ME: {text}");
            renderView();
        }
    }
}