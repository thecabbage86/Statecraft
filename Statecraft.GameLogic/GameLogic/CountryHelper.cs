using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.GameLogic.GameLogic
{
    public static class CountryHelper
    {
        public static Country DeterminePlayerCountry(Game game, Player player)
        {
            Country playerCountry;

            if (player.Id == game.AustriaPlayerId)
            {
                playerCountry = Country.Austria;
            }
            else if (player.Id == game.GermanyPlayerId)
            {
                playerCountry = Country.Germany;
            }
            else if (player.Id == game.EnglandPlayerId)
            {
                playerCountry = Country.England;
            }
            else if (player.Id == game.FrancePlayerId)
            {
                playerCountry = Country.France;
            }
            else if (player.Id == game.ItalyPlayerId)
            {
                playerCountry = Country.Italy;
            }
            else if (player.Id == game.RussiaPlayerId)
            {
                playerCountry = Country.Russia;
            }
            else
            {
                playerCountry = Country.Turkey;
            }

            return playerCountry;
        }
    }
}
