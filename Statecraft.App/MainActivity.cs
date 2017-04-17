using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Statecraft.Common.Models;
using Android.Views;
using Statecraft.App.Adapters;

namespace Statecraft.App
{
    [Activity(Label = "Statecraft", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private Game[] games = new Game[1] { new Game() { Id = 22 } };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //TODO: call API endpoint to retrieve the user's existing games

            TextView yourGamesText = FindViewById<TextView>(Resource.Id.YourGamesText);
            //ListView yourGames = FindViewById<ListView>(Resource.Id.list);

            if (games != null && games.Length > 0)
            {
                yourGamesText.Text = "YOUR GAMES:";
                ListAdapter = new HomeScreenListAdapter(this, games);
            }
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var game = games[position];
            Android.Widget.Toast.MakeText(this, "Game: game.Id", ToastLength.Short);
        }
    }
}

