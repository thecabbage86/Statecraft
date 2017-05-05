using Statecraft.Common.JsonModels.Requests;
using Statecraft.Common.JsonModels.Responses;
using Statecraft.Common.Models;
using Statecraft.Services.Interfaces;
using Statecraft.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Statecraft.Services.Controllers
{
    [Route("gamestate")]
    public class GameStateController : ApiController
    {
        private IGameRepository gameRepo;

        public GameStateController()
        {
            gameRepo = new GameRepositoryFake(); //TODO: dependency injection
        }

        [HttpGet]
        public HttpResponseMessage GetCurrentGameState(int gameId)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Game game;

            try
            {
                game = gameRepo.GetGameById(gameId);
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameStateResponse>(HttpStatusCode.OK, new GameStateResponse(game.CurrentGameState));
        }

        [HttpPost]
        [Route("_services/update")]
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
    }
}
