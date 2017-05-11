using Statecraft.Common.Enums;

namespace Statecraft.Common.DTOs
{
    public class GameRoundDto
    {
        public int Id { get; set; }
        public Season Season { get; set; }
        public Phase Phase { get; set; }
        public int Year { get; set; }
    }
}