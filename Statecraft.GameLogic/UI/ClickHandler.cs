using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using Statecraft.Common.Models.Territories;
using Statecraft.GameLogic.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.GameLogic.UI
{
    public class ClickHandler
    {
        private Player player;
        private Game game;
        private MoveAttempt moveAttempt;
        //private Territory territoryClicked;

        public ClickHandler(Game game, Player player, MoveAttempt moveAttempt)
        {
            this.game = game;
            this.player = player;
            this.moveAttempt = moveAttempt;
        }

        public MoveAttempt Handle(float x, float y)
        {
            Territory territoryClicked = null;

            //TODO: only set territoryClicked if it's a validly selectable territory for this player (from moveAttempt.AllowedNextTerritories)
            if (x >= 1300 && x <= 1590 && y >= 55 && y <= 350)
            {
                territoryClicked = game.CurrentGameState.Map.Territories["St. Petersburg"]; 
            }
            
            if (territoryClicked != null)
            {
                OrdersType orderType = OrdersType.Attack; //TODO: add a modal for selecting order type
                OrdersHandler.Execute(game.CurrentGameState, territoryClicked, orderType, ref moveAttempt);
            }

            return moveAttempt;
        }
    }
}
