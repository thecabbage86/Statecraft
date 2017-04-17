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
using Newtonsoft.Json;
using Statecraft.Common.Models;

namespace Statecraft.App.Activities
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Game);

            var serializedGame = Intent.GetStringExtra("Game");
            var game = JsonConvert.DeserializeObject<Game>(serializedGame);

            var serializedPlayer = Intent.GetStringExtra("Player");
            var player = JsonConvert.DeserializeObject<Player>(serializedPlayer);

            //Window.SetTitle("Game " + game.Id);
            TextView yourGamesText = FindViewById<TextView>(Resource.Id.textView1);
            yourGamesText.Text += game.Id;
        }
    }
}