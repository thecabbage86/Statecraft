using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Statecraft.Common.Models;
using Android.Views;
using Statecraft.App.Adapters;
using System;
using Android.Content;
using Statecraft.App.Activities;
using Newtonsoft.Json;
using Statecraft.GameLogic.Http;

namespace Statecraft.App
{
    [Activity(Label = "Statecraft", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private GameHttpHelper gameHttpHelper = new GameHttpHelper();
        private Game[] games = new Game[2] { new Game() { Id = 22, GermanyPlayerId = Guid.Parse("456e822a-8249-453c-9a02-74a31c1d24ae") },
            new Game() { Id = 223, AustriaPlayerId = Guid.Parse("456e822a-8249-453c-9a02-74a31c1d24ae"), CurrentGameState = new GameState(), HasBegun = true }}; //TODO
        private Player player = new Player() { Id = Guid.Parse("456e822a-8249-453c-9a02-74a31c1d24ae") }; //TODO

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //games = gameHttpHelper.GetGamesByPlayerId(player.Id).Result;

            TextView yourGamesText = FindViewById<TextView>(Resource.Id.YourGamesText);
            //ListView yourGames = FindViewById<ListView>(Resource.Id.list);

            if (games != null && games.Length > 0)
            {
                yourGamesText.Text = "YOUR GAMES:";
                ListAdapter = new HomeScreenListAdapter(this, games, player);
            }
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var game = games[position];

            var gameIntent = new Intent(this, typeof(GameActivity));
            gameIntent.PutExtra("Game", JsonConvert.SerializeObject(game));
            gameIntent.PutExtra("Player", JsonConvert.SerializeObject(player));
            StartActivity(gameIntent);
            //Android.Widget.Toast.MakeText(this, "Game: game.Id", ToastLength.Short);
            //TODO: open new view/activity
        }
    }
}

