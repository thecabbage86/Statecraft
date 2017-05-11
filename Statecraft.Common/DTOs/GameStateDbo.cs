using System.Collections.Generic;

namespace Statecraft.Common.DTOs
{
    public class GameStateDbo
    {
        public long Id { get; set; }
        public int GameRoundId { get; set; } 
        public IList<TerritoryDbo> Map { get; set; }
    }
}