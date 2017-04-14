using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using Statecraft.Services.Interfaces;
using Statecraft.Services.Models;
using Statecraft.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Statecraft.Services.Controllers
{
    public class GameController : ApiController
    {
        private IGameRepository gameRepo;

        public GameController()
        {
            gameRepo = new GameRepository(); //TODO: dependency injection
        }

        [HttpPost]
        public HttpResponseMessage CreateNewGame(CreateNewGameRequest createNewGameRequest)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest); 
            }

            var game = new Game() { CreatorPlayerId = createNewGameRequest.StartGame.FirstPlayerId, Options = createNewGameRequest.StartGame.Options };

            switch (createNewGameRequest.StartGame.SelectedCountry)
            {
                case Country.England:
                    game.EnglandPlayerId = createNewGameRequest.StartGame.FirstPlayerId; break;
                case Country.France:
                    game.FrancePlayerId = createNewGameRequest.StartGame.FirstPlayerId; break;
                case Country.Italy:
                    game.ItalyPlayerId = createNewGameRequest.StartGame.FirstPlayerId; break;
                case Country.Russia:
                    game.RussiaPlayerId = createNewGameRequest.StartGame.FirstPlayerId; break;
                case Country.Austria:
                    game.AustriaPlayerId = createNewGameRequest.StartGame.FirstPlayerId; break;
                case Country.Germany:
                    game.GermanyPlayerId = createNewGameRequest.StartGame.FirstPlayerId; break;
                case Country.Turkey:
                default:
                    game.TurkeyPlayerId = createNewGameRequest.StartGame.FirstPlayerId; break;
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

            return Request.CreateResponse<Game>(game);
        }

        [HttpPost]
        public HttpResponseMessage StartGame(StartGameRequest startGameRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                var game = gameRepo.GetGameById(startGameRequest.StartGame.GameId);

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

            throw new NotImplementedException();
        }

        [HttpGet]
        public HttpResponseMessage GetCurrentGameState(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}