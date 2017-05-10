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
        Game CreateNewGame(Game game);
        Game GetGameById(Guid id);
        IList<Game> GetGamesByPlayerId(Guid playerId);
        Game UpdateGame(Game game);
    }
}
