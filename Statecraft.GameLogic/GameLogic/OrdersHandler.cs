using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.GameLogic.GameLogic
{
    public static class OrdersHandler
    {
        public static MoveAttempt SetFirstTerritoriesAllowed(Game game, Country playerCountry)
        {
            return new MoveAttempt()
            {
                AllowedNextTerritories = game.CurrentGameState.Territories.Where(t => t.OccupyingUnit != null && t.OccupyingUnit.Country == playerCountry).ToList()
            };
        }

        public static void Execute(GameState gameState, Common.Models.Territory selectedTerritory, OrdersType orderType, ref MoveAttempt moveAttempt)
        {
            if (moveAttempt.SelectedTerritory == null)
            {
                moveAttempt = new MoveAttempt();
                moveAttempt.SelectedTerritory = selectedTerritory;
                moveAttempt.OrdersType = orderType;

                if(orderType == OrdersType.Attack)
                {
                    HandleFirstAttackMove(gameState, ref moveAttempt);
                }
                else if(orderType == OrdersType.Support)
                {
                    HandleFirstSupportMove(gameState, ref moveAttempt);
                }
                else if(orderType == OrdersType.Convoy)
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
            //gameState.Territories
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
