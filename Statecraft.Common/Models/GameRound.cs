using Statecraft.Common.Constants;
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
        public GameRound() { }
        public GameRound(int gameRoundDboId)
        {
            Year = GameValues.STARTING_YEAR + (int)Math.Floor((double)(gameRoundDboId - 1) / 5);
            int roundInYear = ((gameRoundDboId - 1) % 5) + 1;
            switch (roundInYear)
            {
                case 1:
                    Season = Season.Spring;
                    Phase = Phase.Movement;
                    break;
                case 2:
                    Season = Season.Spring;
                    Phase = Phase.Build;
                    break;
                case 3:
                    Season = Season.Fall;
                    Phase = Phase.Movement;
                    break;
                case 4:
                    Season = Season.Fall;
                    Phase = Phase.Retreat;
                    break;
                case 5:
                    Season = Season.Fall;
                    Phase = Phase.Build;
                    break;
            }
        }
        public Season Season { get; set; }

        public Phase Phase { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return Season.ToString() + " " + Year.ToString() + " " + Phase.ToString();
        }
    }
}
