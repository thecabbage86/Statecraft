using Statecraft.Common.Models;
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

            if (player.Id == game.AustriaPlayerId)
            {
                displayText += "Country: Austria";
            }
            else if (player.Id == game.GermanyPlayerId)
            {
                displayText += "Country: Germany";
            }
            else if (player.Id == game.EnglandPlayerId)
            {
                displayText += "Country: England";
            }
            else if (player.Id == game.FrancePlayerId)
            {
                displayText += "Country: France";
            }
            else if (player.Id == game.ItalyPlayerId)
            {
                displayText += "Country: Italy";
            }
            else if (player.Id == game.RussiaPlayerId)
            {
                displayText += "Country: Russia";
            }
            else if (player.Id == game.TurkeyPlayerId)
            {
                displayText += "Country: Turkey";
            }

            if(game.CurrentGameState != null && game.CurrentGameState.Round != null)
            {
                displayText += ", " + game.CurrentGameState.Round.ToString();
            }

            return displayText;
        }

    }
}
