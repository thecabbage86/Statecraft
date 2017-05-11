using Statecraft.Common.DTOs;
using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Services.Interfaces
{
    public interface IGameRepository
    {
        GameDto CreateNewGame(GameDto game);
        GameDto GetGameById(Guid id);
        IList<GameDto> GetGamesByPlayerId(Guid playerId);
        GameDto UpdateGame(GameDto game);
    }
}
