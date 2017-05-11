using System.Collections.Generic;

namespace Statecraft.Common.DTOs
{
    public class GameStateDto
    {
        public long Id { get; set; }
        public int GameRoundId { get; set; } 
        public IList<TerritoryDto> Map { get; set; }
    }
}