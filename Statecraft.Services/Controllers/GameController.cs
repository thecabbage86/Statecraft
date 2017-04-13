using Statecraft.Common.Models;
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
        [HttpGet]
        public HttpResponseMessage SetInitialGameBoard()
        {
            GameState gameState = new GameState();
            

            //call repo to save to DB


            return Request.CreateResponse<GameState>(gameState);
        }

        [HttpGet]
        public HttpResponseMessage GetGameState()
        {
            throw new NotImplementedException();
        }
    }
}