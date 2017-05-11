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
        public GameDto CreateNewGame(GameDto game)
        {
            throw new NotImplementedException();
        }

        public GameDto GetGameById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<GameDto> GetGamesByPlayerId(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public GameDto UpdateGame(GameDto game)
        {
            throw new NotImplementedException();
        }
    }
}