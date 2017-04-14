using Statecraft.Common.Models;
using Statecraft.Services.Interfaces;
using Statecraft.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public HttpResponseMessage StartGame()
        {
            Game game = new Game() { CurrentGameState = new GameState() };
            

            //call repo to save to DB


            return Request.CreateResponse<Game>(game);
        }

        [HttpGet]
        public HttpResponseMessage GetCurrentGameState(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}