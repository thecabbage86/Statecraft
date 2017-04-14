using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models
{
    public class Game
    {
        public int Id { get; set; }
        public GameOptions Options { get; set; }
        public TimeSpan RoundLength { get; set; }
        public GameState CurrentGameState { get; set; }
        public bool IsFinished { get; set; }
        public IList<Player> Players { get; set; }
        public IList<Player> Winners { get; set; }
    }
}
