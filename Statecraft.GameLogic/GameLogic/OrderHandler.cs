using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.GameLogic.GameLogic
{
    public static class OrderHandler
    {
        public static MoveAttempt SetFirstTerritoriesAllowed(Game game, Player player)
        {
            MoveAttempt moveAttempt = new MoveAttempt();

            //TODO: place playerCountry in a model somewhere
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

            moveAttempt.AllowedNextTerritories = game.CurrentGameState.Territories.Where(t => t.OccupyingUnit != null && t.OccupyingUnit.Country == playerCountry).ToList();

            return moveAttempt;
        }

        public static void Execute(GameState gameState, Common.Models.Territory selectedTerritory, OrderType orderType, ref MoveAttempt moveAttempt)
        {
            if (moveAttempt.SelectedTerritory == null)
            {
                moveAttempt = new MoveAttempt();
                moveAttempt.SelectedTerritory = selectedTerritory;
                moveAttempt.OrderType = orderType;

                if(orderType == OrderType.Attack)
                {
                    HandleFirstAttackMove(gameState, ref moveAttempt);
                }
                else if(orderType == OrderType.Support)
                {
                    HandleFirstSupportMove(gameState, ref moveAttempt);
                }
                else if(orderType == OrderType.Convoy)
                {
                    HandleFirstConvoyMove(gameState, ref moveAttempt);
                }
            }
            else
            {
                //TODO: handle SupportedOrConvoyedTerritory and DestinationTerritory
            }

        }

        private static void HandleFirstAttackMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }
        private static void HandleFirstSupportMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleFirstConvoyMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }
    }
}
