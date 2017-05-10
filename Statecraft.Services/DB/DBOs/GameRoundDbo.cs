using Statecraft.Common.Enums;

namespace Statecraft.Services.DB.DBOs
{
    public class GameRoundDbo
    {
        public int Id { get; set; }
        public Season Season { get; set; }
        public Phase Phase { get; set; }
        public int Year { get; set; }
    }
}