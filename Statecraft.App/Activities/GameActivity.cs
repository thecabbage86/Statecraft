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
using Statecraft.GameLogic.GameLogic;

namespace Statecraft.App.Activities
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        private Game game;
        private Player player;
        private ImageView map;
        private ClickHandler clickHandler;
        private MoveAttempt moveAttempt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Game);

            var serializedGame = Intent.GetStringExtra("Game");
            game = JsonConvert.DeserializeObject<Game>(serializedGame);

            var serializedPlayer = Intent.GetStringExtra("Player");
            player = JsonConvert.DeserializeObject<Player>(serializedPlayer);

            moveAttempt = OrderHandler.SetFirstTerritoriesAllowed(game, player);
            clickHandler = new ClickHandler(game, player, moveAttempt);

            map = FindViewById<ImageView>(Resource.Id.map);
            map.Touch += (s, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    moveAttempt = clickHandler.Handle(e.Event.GetX(), e.Event.GetY());
                }
            };
            //map.Click += (s, e) =>
            //{
            //    //Toast.MakeText(ActivationContext, "Clicked on map", ToastLength.Long);
            //    clickHandler.Handle(e.Event.GetX(), e.Event.GetY());
            //};
        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            Window.SetTitle(DisplayTextHelper.GetGameStateDisplayText(game, player));
        }

        protected override void OnResume()
        {
            base.OnResume();

            //TODO: handle refreshing of game data by calling server
        }
    }
}