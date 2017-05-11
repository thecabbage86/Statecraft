using AutoMapper;
using Statecraft.Common.DTOs;
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
        public HttpResponseMessage GetCurrentGameState(Guid gameId)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            GameDto game;

            try
            {
                game = gameRepo.GetGameById(gameId);
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameStateResponse>(HttpStatusCode.OK, new GameStateResponse(new Game(game).CurrentGameState));
        }

        [HttpPost]
        [Route("_services/update")]
        public HttpResponseMessage UpdateGameState(UpdateGameStateRequest updateGameStateRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            GameDto gameDto;

            try
            {
                gameDto = gameRepo.GetGameById(updateGameStateRequest.UpdateGameState.GameId);

                //TODO: refactor/possibly fix
                var game = new Game(gameDto);
                game.CurrentGameState = updateGameStateRequest.UpdateGameState.GameState;
                gameDto = game.ToDto();

                gameRepo.UpdateGame(gameDto);
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse<GameResponse>(HttpStatusCode.OK, new GameResponse(new Game(gameDto)));
        }
    }
}
