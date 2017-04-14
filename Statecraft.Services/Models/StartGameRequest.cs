using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Services.Models
{
    public class StartGameRequest
    {
        public StartGameModel StartGame { get; set; }
    }

    public class StartGameModel
    {
        public IList<Player> Players { get; set; }
        public GameOptions Options { get; set; }
    }
}