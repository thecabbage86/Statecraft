using System.Collections.Generic;

namespace Statecraft.Services.DB.DBOs
{
    public class GameStateDbo
    {
        public long Id { get; set; }
        public int GameRoundId { get; set; } 
        public IList<TerritoryDbo> Map { get; set; }
    }
}