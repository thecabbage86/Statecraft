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
using Statecraft.Common.Models;

namespace Statecraft.App.Adapters
{
    public class HomeScreenListAdapter : BaseAdapter<Game>
    {
        Game[] games;
        Activity context;
        public HomeScreenListAdapter(Activity context, Game[] items) : base()
        {
            this.context = context;
            this.games = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Game this[int position]
        {
            get { return games[position]; }
        }
        public override int Count
        {
            get { return games.Length; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = "Game id:" + games[position].Id;
            return view;
        }
    }
}