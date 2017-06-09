using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using Statecraft.Common.Models.Territories;
using Statecraft.GameLogic.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.GameLogic.GameLogic
{
    //TODO: remove any unncessary params
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

                if(orderType == OrdersType.Attack || orderType == OrdersType.Support || orderType == OrdersType.Defend)
                {
                    HandleFirstAttackSupportOrDefendMove(gameState, ref moveAttempt);
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
                    HandleDestinationMove(gameState, selectedTerritory, ref moveAttempt);
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
                        HandleDestinationMove(gameState, selectedTerritory, ref moveAttempt);
                    }
                    else if (orderType == OrdersType.Convoy)
                    {
                        HandleDestinationMove(gameState, selectedTerritory, ref moveAttempt);
                    }
                }
            }

        }

        private static void HandleFirstAttackSupportOrDefendMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            //allowed moves: adjacent territories, taking UnitType into account
            if (moveAttempt.SelectedTerritory.OccupyingUnit.UnitType == UnitType.Land)
            {
                moveAttempt.AllowedNextTerritories = moveAttempt.SelectedTerritory.Neighbors.Where(n => n.Type == TerritoryType.Land).ToList();
            }
            else if(moveAttempt.SelectedTerritory.OccupyingUnit.UnitType == UnitType.Sea && moveAttempt.SelectedTerritory.Type == TerritoryType.Sea)
            {
                moveAttempt.AllowedNextTerritories = moveAttempt.SelectedTerritory.Neighbors;
            }
            else
            {
                moveAttempt.AllowedNextTerritories = moveAttempt.SelectedTerritory.Neighbors.Where(n => n.Type == TerritoryType.Sea || n.Coasts != null).ToList();
            }
        }

        private static void HandleFirstConvoyMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleSupportMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            //allowed moves: adjacent territories, taking UnitType into account
            if (moveAttempt.SupportedOrConvoyedTerritory.OccupyingUnit.UnitType == UnitType.Land)
            {
                moveAttempt.AllowedNextTerritories = moveAttempt.SupportedOrConvoyedTerritory.Neighbors.Where(n => n.Type == TerritoryType.Land).ToList();
            }
            else if (moveAttempt.SupportedOrConvoyedTerritory.OccupyingUnit.UnitType == UnitType.Sea && moveAttempt.SupportedOrConvoyedTerritory.Type == TerritoryType.Sea)
            {
                moveAttempt.AllowedNextTerritories = moveAttempt.SupportedOrConvoyedTerritory.Neighbors;
            }
            else
            {
                moveAttempt.AllowedNextTerritories = moveAttempt.SupportedOrConvoyedTerritory.Neighbors.Where(n => n.Type == TerritoryType.Sea || n.Coasts != null).ToList();
            }
        }

        private static void HandleConvoyMove(GameState gameState, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleDefendMove(GameState gameState, Territory selectedTerritory, ref MoveAttempt moveAttempt)
        {
            throw new NotImplementedException();
        }

        private static void HandleDestinationMove(GameState gameState, Territory selectedTerritory, ref MoveAttempt moveAttempt)
        {
            moveAttempt.DestinationTerritory = selectedTerritory;
            moveAttempt.IsFinished = true;
        }
    }
}
