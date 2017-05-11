using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;
using Statecraft.Common.DTOs;

namespace Statecraft.Services.Repositories
{
    public class GameRepository : IGameRepository
    {
        public GameDbo CreateNewGame(GameDbo game)
        {
            throw new NotImplementedException();
        }

        public GameDbo GetGameById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<GameDbo> GetGamesByPlayerId(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public GameDbo UpdateGame(GameDbo game)
        {
            throw new NotImplementedException();
        }
    }
}