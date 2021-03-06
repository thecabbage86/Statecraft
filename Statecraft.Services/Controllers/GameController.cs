﻿using AutoMapper;
using Statecraft.Common.DTOs;
using Statecraft.Common.Enums;
using Statecraft.Common.JsonModels.Requests;
using Statecraft.Common.JsonModels.Responses;
using Statecraft.Common.Models;
using Statecraft.Services.Interfaces;
using Statecraft.Services.Models;
using Statecraft.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Statecraft.Services.Controllers
{
    /// <summary>
    /// Create, start, and retrieve games.
    /// </summary>
    [EnableCors(origins: "http://localhost:4200", headers:"*", methods:"*")]
    [Route("games")]
    public class GameController : ApiController
    {
        private IGameRepository _gameRepo;

        public GameController(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        /// <summary>
        /// Get games by player ID.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>The list of games associated with the player with playerId.</returns>
        [HttpGet]
        public HttpResponseMessage GetGames([FromUri]Guid? playerId = null)
        {
            IList<Game> games = new List<Game>();

            try
            {
                var gameDtos = _gameRepo.GetGamesByPlayerId((Guid)playerId);
                foreach(var dto in gameDtos)
                {
                    games.Add(new Game(dto));
                }
            }
            catch (Exception ex)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameResponse>(HttpStatusCode.OK, new GameResponse(games));
        }

        [HttpGet]
        [Route("~/games/{gameId}")]
        public HttpResponseMessage GetGameById(Guid gameId)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            GameDto game;

            try
            {
                game = _gameRepo.GetGameById(gameId);
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameResponse>(HttpStatusCode.OK, new GameResponse(new Game(game)));
        }

        [HttpPost]
        [Route("_services/create")]
        public HttpResponseMessage CreateNewGame(CreateNewGameRequest createNewGameRequest)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest); 
            }

            var game = new Game() { CreatorPlayerId = createNewGameRequest.CreateGame.FirstPlayerId, Options = createNewGameRequest.CreateGame.Options,
                CurrentGameState = new GameState() };

            switch (createNewGameRequest.CreateGame.SelectedCountry)
            {
                case Country.England:
                    game.EnglandPlayerId = createNewGameRequest.CreateGame.FirstPlayerId; break;
                case Country.France:
                    game.FrancePlayerId = createNewGameRequest.CreateGame.FirstPlayerId; break;
                case Country.Italy:
                    game.ItalyPlayerId = createNewGameRequest.CreateGame.FirstPlayerId; break;
                case Country.Russia:
                    game.RussiaPlayerId = createNewGameRequest.CreateGame.FirstPlayerId; break;
                case Country.Austria:
                    game.AustriaPlayerId = createNewGameRequest.CreateGame.FirstPlayerId; break;
                case Country.Germany:
                    game.GermanyPlayerId = createNewGameRequest.CreateGame.FirstPlayerId; break;
                case Country.Turkey:
                default:
                    game.TurkeyPlayerId = createNewGameRequest.CreateGame.FirstPlayerId; break;
            }

            try
            {
                _gameRepo.CreateNewGame(game.ToDto());
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameResponse>(HttpStatusCode.OK, new GameResponse(game));
        }

        [HttpPost]
        [Route("_services/start")]
        public HttpResponseMessage StartGame(StartGameRequest startGameRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            GameDto game;

            try
            {
                game = _gameRepo.GetGameById(startGameRequest.StartGame.GameId);

                //game.Options = startGameRequest.StartGame.Options;
                game.IsGunboatOption = startGameRequest.StartGame.Options.IsGunboat;
                game.IsRankedOption = startGameRequest.StartGame.Options.IsRanked;
                game.RoundLengthOption = startGameRequest.StartGame.Options.RoundLength;

                game.EnglandPlayerId = startGameRequest.StartGame.EnglandPlayerId;
                game.AustriaPlayerId = startGameRequest.StartGame.AustriaPlayerId;
                game.FrancePlayerId = startGameRequest.StartGame.FrancePlayerId;
                game.GermanyPlayerId = startGameRequest.StartGame.GermanyPlayerId;
                game.ItalyPlayerId = startGameRequest.StartGame.ItalyPlayerId;
                game.RussiaPlayerId = startGameRequest.StartGame.RussiaPlayerId;
                game.TurkeyPlayerId = startGameRequest.StartGame.TurkeyPlayerId;
                game.HasBegun = true;

                _gameRepo.UpdateGame(game);
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameResponse>(HttpStatusCode.OK, new GameResponse(new Game(game)));
        }
    }
}