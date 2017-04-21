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
            Common.Models.Territory territoryClicked = null;

            //TODO: Map out each territory using polygon logic: http://stackoverflow.com/questions/217578/how-can-i-determine-whether-a-2d-point-is-within-a-polygon
            //only set territoryClicked if it's a validly selectable territory for this player (from moveAttempt.AllowedNextTerritories)
            if (x >= 1300 && x <= 1590 && y >= 55 && y <= 350)
            {
                territoryClicked = game.CurrentGameState.Territories.Vertices.FirstOrDefault(t => t.Name == "St. Petersburg");
            }
            //TODO: condition for each territory
            
            if (territoryClicked != null)
            {
                OrdersType orderType = OrdersType.Attack; //TODO: add a modal for selecting order type
                OrdersHandler.Execute(game.CurrentGameState, territoryClicked, orderType, ref moveAttempt);
            }

            return moveAttempt;
        }
    }
}
