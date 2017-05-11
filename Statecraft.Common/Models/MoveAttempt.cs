using Statecraft.Common.DTOs;
using Statecraft.Common.Enums;
using Statecraft.Common.Models.Territories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models
{
    public class MoveAttempt
    {
        public OrdersType OrdersType { get; set; }
        public Territory SelectedTerritory { get; set; }
        public Territory SupportedOrConvoyedTerritory { get; set; }
        public Territory DestinationTerritory { get; set; }

        public IList<Territory> AllowedNextTerritories { get; set; }
        public bool IsFinished { get; set; }
        //public bool MoveSaved { get; set; }

        public MoveAttempt(){}

        //TODO: complete this mapping
        public MoveAttempt(MoveAttemptDto dto)
        {
            this.OrdersType = dto.OrdersType;
            //this.SelectedTerritory
        }
    }
}
