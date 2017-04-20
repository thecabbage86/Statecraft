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
using Statecraft.GameLogic.UI;

namespace Statecraft.App.Activities
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        private Game game;
        private Player player;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Game);

            var serializedGame = Intent.GetStringExtra("Game");
            game = JsonConvert.DeserializeObject<Game>(serializedGame);

            var serializedPlayer = Intent.GetStringExtra("Player");
            player = JsonConvert.DeserializeObject<Player>(serializedPlayer);

            
        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            Window.SetTitle(DisplayTextHelper.GetGameStateDisplayText(game, player));
        }
    }
}