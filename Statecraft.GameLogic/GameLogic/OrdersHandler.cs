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
                AllowedNextTerritories = game.CurrentGameState.Map.Territories.Where(t => t.OccupyingUnit != null && t.OccupyingUnit.Country == playerCountry).ToList()
            };
        }

        public static void Execute(GameState gameState, Common.Models.Territories.Territory selectedTerritory, OrdersType orderType, ref MoveAttempt moveAttempt)
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
                if (orderType == OrdersType.Attack)
                {
                    HandleAttackDestinationMove(gameState, ref moveAttempt);
                }

                if (moveAttempt.SupportedOrConvoyedTerritory == null)
                {
                    if (orderType == OrdersType.Support)
                    {
                        HandleSupportMove(gameState, ref moveAttempt);
                    }
                    else if (orderType == OrdersType.Convoy)
                    {
                        HandleConvoyMove(gameState, ref moveAttempt);
                    }
                }
                else
                {
                    if (orderType == OrdersType.Support)
                    {
                        HandleSupportDestinationMove(gameState, ref moveAttempt);
                    }
                    else if (orderType == OrdersType.Convoy)
                    {
                        HandleConvoyDestinationMove(gameState, ref moveAttempt);
                    }
                }
            }

        }

        private static void HandleFirstAttackMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            //allowed moves: adjacent territories, taking UnitType into account
            if (moveAttempt.SelectedTerritory.OccupyingUnit.UnitType == UnitType.Land)
            {
                moveAttempt.AllowedNextTerritories = moveAttempt.SelectedTerritory.Neighbors.Where(n => n.Type == TerritoryType.Land).ToList();
            }
            else
            {
                moveAttempt.AllowedNextTerritories = moveAttempt.SelectedTerritory.Neighbors;
            }
        }
        private static void HandleFirstSupportMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleFirstConvoyMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleAttackDestinationMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleSupportMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleConvoyMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleSupportDestinationMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleConvoyDestinationMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }
    }
}
