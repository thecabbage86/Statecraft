using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.JsonModels.Responses
{
    public class GameStateResponse
    {
        public GameStateResponse(GameState gameState)
        {
            GameStates = new List<GameState>() { gameState };
        }

        public IList<GameState> GameStates { get; set; }
    }
}
