using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Services.Models.Responses
{
    public class GameResponse
    {
        public Game Game { get; set; }

        public GameResponse(Game game)
        {
            Game = game;
        }
    }
}