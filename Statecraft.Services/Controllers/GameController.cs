using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using Statecraft.Services.Interfaces;
using Statecraft.Services.Models;
using Statecraft.Services.Models.Requests;
using Statecraft.Services.Models.Responses;
using Statecraft.Services.Repositories;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Statecraft.Services.Controllers
{
    public class GameController : ApiController
    {
        private IGameRepository gameRepo;

        public GameController()
        {
            gameRepo = new GameRepositoryFake(); //TODO: dependency injection
        }

        [HttpPost]
        public HttpResponseMessage CreateNewGame(CreateNewGameRequest createNewGameRequest)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest); 
            }

            var game = new Game() { CreatorPlayerId = createNewGameRequest.CreateGame.FirstPlayerId, Options = createNewGameRequest.CreateGame.Options };

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
                gameRepo.CreateNewGame(game);
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameResponse>(HttpStatusCode.OK, new GameResponse(game));
        }

        [HttpPost]
        public HttpResponseMessage StartGame(StartGameRequest startGameRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Game game;

            try
            {
                game = gameRepo.GetGameById(startGameRequest.StartGame.GameId);

                game.Options = startGameRequest.StartGame.Options;
                game.EnglandPlayerId = startGameRequest.StartGame.EnglandPlayerId;
                game.AustriaPlayerId = startGameRequest.StartGame.AustriaPlayerId;
                game.FrancePlayerId = startGameRequest.StartGame.FrancePlayerId;
                game.GermanyPlayerId = startGameRequest.StartGame.GermanyPlayerId;
                game.ItalyPlayerId = startGameRequest.StartGame.ItalyPlayerId;
                game.RussiaPlayerId = startGameRequest.StartGame.RussiaPlayerId;
                game.TurkeyPlayerId = startGameRequest.StartGame.TurkeyPlayerId;
                game.HasBegun = true;

                gameRepo.UpdateGame(game);
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameResponse>(HttpStatusCode.OK, new GameResponse(game));
        }

        [HttpPost]
        public HttpResponseMessage UpdateGameState(UpdateGameStateRequest updateGameStateRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Game game;

            try
            {
                game = gameRepo.GetGameById(updateGameStateRequest.UpdateGameState.GameId);

                game.CurrentGameState = updateGameStateRequest.UpdateGameState.GameState;

                gameRepo.UpdateGame(game);
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameResponse>(HttpStatusCode.OK, new GameResponse(game));
        }

        [HttpGet]
        public HttpResponseMessage GetCurrentGameState(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}