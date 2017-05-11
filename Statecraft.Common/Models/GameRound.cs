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
        public Season Season { get; set; }

        public Phase Phase { get; set; }
        public int Year { get; set; }

        public int GameRoundId
        {
            get
            {
                int seasonRoundOffset;

                if(Season == Season.Spring && Phase == Phase.Movement)
                {
                    seasonRoundOffset = 0;
                }
                else if (Season == Season.Spring && Phase == Phase.Retreat)
                {
                    seasonRoundOffset = 1;
                }
                else if (Season == Season.Fall && Phase == Phase.Movement)
                {
                    seasonRoundOffset = 2;
                }
                else if (Season == Season.Fall && Phase == Phase.Retreat)
                {
                    seasonRoundOffset = 3;
                }
                else //if (Season == Season.Fall && Phase == Phase.Build)
                {
                    seasonRoundOffset = 4;
                }

                return (Year - GameValues.STARTING_YEAR) * 5 + 1 + seasonRoundOffset;
            }
        }

        public GameRound() { }
        public GameRound(int gameRoundDtoId)
        {
            Year = GameValues.STARTING_YEAR + (int)Math.Floor((double)(gameRoundDtoId - 1) / 5);
            int roundInYear = ((gameRoundDtoId - 1) % 5) + 1;
            switch (roundInYear)
            {
                case 1:
                    Season = Season.Spring;
                    Phase = Phase.Movement;
                    break;
                case 2:
                    Season = Season.Spring;
                    Phase = Phase.Retreat;
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

        public override string ToString()
        {
            return Season.ToString() + " " + Year.ToString() + " " + Phase.ToString();
        }
    }
}
