using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using Statecraft.GameLogic.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.GameLogic.UI
{
    public static class DisplayTextHelper
    {
        public static string GetGameDisplayText(Game game, Player player)
        {
            string displayText = "Id: " + game.Id + ", Status: ";

            if (!game.HasBegun)
            {
                displayText += "Waiting for players, ";
            }
            else if (game.IsFinished)
            {
                displayText += "Finished, ";
            }
            else
            {
                displayText += "In progress, ";
            }

            displayText += "Country: " + Enum.GetName(typeof(Country), CountryHelper.DeterminePlayerCountry(game, player));

            if(game.CurrentGameState != null && game.CurrentGameState.Round != null)
            {
                displayText += ", " + game.CurrentGameState.Round.ToString();
            }

            return displayText;
        }

        public static string GetGameStateDisplayText(Game game, Country playerCountry)
        {
            string displayText = Enum.GetName(typeof(Country), playerCountry);
            displayText += ", " + game.CurrentGameState.Round.Season + ", " + game.CurrentGameState.Round.Year + " (" + game.CurrentGameState.Round.Phase + ")";
            return displayText;
        }

    }
}
