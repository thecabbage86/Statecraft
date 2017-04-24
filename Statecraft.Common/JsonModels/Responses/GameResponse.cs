using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Common.JsonModels.Responses
{
    /// <summary>
    /// Games
    /// </summary>
    public class GameResponse
    {
        /// <summary>
        /// List of games
        /// </summary>
        public IList<Game> Games { get; set; }

        public GameResponse() { }

        public GameResponse(Game game)
        {
            Games = new List<Game>() { game };
        }

        public GameResponse(IList<Game> games)
        {
            Games = games;
        }
    }
}