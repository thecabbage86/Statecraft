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
using Statecraft.GameLogic.UI;

namespace Statecraft.App.Adapters
{
    public class HomeScreenListAdapter : BaseAdapter<Game>
    {
        private Game[] games;
        private Player player;
        Activity context;
        public HomeScreenListAdapter(Activity context, Game[] items, Player player) : base()
        {
            this.context = context;
            this.games = items;
            this.player = player;
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

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = DisplayTextHelper.GetGameDisplayText(games[position], player);
            return view;
        }

       
    }
}