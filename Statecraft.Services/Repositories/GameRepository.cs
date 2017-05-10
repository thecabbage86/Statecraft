using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;

namespace Statecraft.Services.Repositories
{
    public class GameRepository : IGameRepository
    {
        public Game CreateNewGame(Game game)
        {
            throw new NotImplementedException();
        }

        public Game GetGameById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Game> GetGamesByPlayerId(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Game UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}