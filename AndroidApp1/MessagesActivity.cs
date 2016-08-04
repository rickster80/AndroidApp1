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
    [Activity(Label = "Messages")]
    public class MessagesActivity : SecureBaseListActivity
    {
        Message[] _messages;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Messages);
            var data = MockMessages();
            _messages = data.ToArray();
            ListAdapter = new MessageAdapter(this, _messages);
            // Create your application here
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            var mess = new Intent(this, typeof(ConversationActivity));
            mess.PutExtra("SenderName", _messages[position].From);
            StartActivity(mess);
        }
        public List<Message> MockMessages(int num = 20)
        {
            var messages = new List<Message>();
            for (int i = 0; i < num; i++){
                messages.Add(new Message()
                {
                    From = $"Person{i}",
                    DateSent = DateTime.Now.AddDays(-i).Date,
                    Subject = $"A message from Person {i}"
                });
            }
            return messages.OrderByDescending(m => m.DateSent).ToList();
        }

    }

    public class Message
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public DateTime DateSent { get; set; }
    }
    public class MessageAdapter : BaseAdapter<Message>
    {
        Activity _context;
        Message[] _messages;

        public MessageAdapter(Activity context, Message[] messages)
        {
            _context = context;
            _messages = messages;
        }

        public override Message this[int position]
        {
            get
            {
                return _messages[position];
            }
        }

        public override int Count
        {
            get
            {
                return _messages.Length;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if(view == null)
            {
                view = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleExpandableListItem2, null);
            }
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = _messages[position].From;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = _messages[position].Subject;

            return view;
        }
    }
}