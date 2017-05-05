﻿using System;
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
using Statecraft.Common.Enums;
using Statecraft.GameLogic.Http;

namespace Statecraft.App.Activities
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        private OrdersHttpHelper ordersHttpHelper;
        private GameStateHttpHelper gameStateHttpHelper;
        private Game game;
        private Player player;
        private Country playerCountry;
        private ImageView map;
        private ClickHandler clickHandler;
        private MoveAttempt moveAttempt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Game);

            ordersHttpHelper = new OrdersHttpHelper();
            gameStateHttpHelper = new GameStateHttpHelper();

            var serializedGame = Intent.GetStringExtra("Game");
            game = JsonConvert.DeserializeObject<Game>(serializedGame);

            var serializedPlayer = Intent.GetStringExtra("Player");
            player = JsonConvert.DeserializeObject<Player>(serializedPlayer);

            playerCountry = CountryHelper.DeterminePlayerCountry(game, player);

            moveAttempt = OrdersHandler.SetFirstTerritoriesAllowed(game, playerCountry);
            clickHandler = new ClickHandler(game, player, moveAttempt);

            map = FindViewById<ImageView>(Resource.Id.map);
            map.Touch += (s, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    moveAttempt = clickHandler.Handle(e.Event.GetX(), e.Event.GetY());
                    if(moveAttempt.IsFinished)
                    {
                        CompleteMove();
                        var newGameState = GetCurrentGameState();
                        //if game progressed to next round, reload UI with new game state
                        if(newGameState != null && newGameState.Round.Phase != game.CurrentGameState.Round.Phase)
                        {
                            StartNewGameRound(newGameState);
                        }
                    }
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
            Window.SetTitle(DisplayTextHelper.GetGameStateDisplayText(game, playerCountry));
        }

        protected override void OnResume()
        {
            base.OnResume();

            var newGameState = GetCurrentGameState();
            //if game progressed to next round, reload UI with new game state
            if (newGameState != null && newGameState.Round.Phase != game.CurrentGameState.Round.Phase)
            {
                StartNewGameRound(newGameState);
            }
        }

        private void CompleteMove()
        {
            try
            {
                ordersHttpHelper.SaveOrders(game.Id, moveAttempt).Wait();
                //TODO: update UI
                moveAttempt = null;
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                //TODO: log error
                Toast.MakeText(ApplicationContext, "A communication error occurred.", ToastLength.Long);
            }
        }

        private GameState GetCurrentGameState()
        {
            GameState newGameState = null;

            try
            {
                newGameState = gameStateHttpHelper.GetGameState(game.Id).Result;
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                //TODO: log error
                Toast.MakeText(ApplicationContext, "A communication error occurred.", ToastLength.Long);
            }

            return newGameState;
        }

        private void StartNewGameRound(GameState newGameState)
        {
            game.CurrentGameState = newGameState;

            //TODO: reload UI with new game state
            //iterate through territories via graph, display new map
            throw new NotImplementedException();
        }
    }
}