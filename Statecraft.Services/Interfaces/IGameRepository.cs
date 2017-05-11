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
        GameDbo CreateNewGame(GameDbo game);
        GameDbo GetGameById(Guid id);
        IList<GameDbo> GetGamesByPlayerId(Guid playerId);
        GameDbo UpdateGame(GameDbo game);
    }
}
