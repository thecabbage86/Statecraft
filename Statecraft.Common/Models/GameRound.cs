using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models
{
    public class GameRound
    {
        public Season Season { get; set; }

        public Phase Phase { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return Season.ToString() + " " + Year.ToString() + " " + Phase.ToString();
        }
    }
}
