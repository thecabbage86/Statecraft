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

        public MoveAttempt(OrdersDto dto)
        {
            this.OrdersType = dto.OrdersType;
            this.SelectedTerritory = new Territory(dto.SelectedTerritoryId);
            this.DestinationTerritory = dto.DestinationTerritoryId != null ? new Territory((int)dto.DestinationTerritoryId) : null;
            this.SupportedOrConvoyedTerritory = dto.SupportedOrConvoyedTerritoryId != null ? new Territory((int)dto.SupportedOrConvoyedTerritoryId) : null;
        }

        public OrdersDto ToDbo(Guid gameId)
        {
            return new OrdersDto()
            {
                GameId = gameId,
                OrdersType = this.OrdersType,
                DestinationTerritoryId = this.DestinationTerritory != null ? (int?)this.DestinationTerritory.Id : null,
                SelectedTerritoryId = this.SelectedTerritory.Id,
                SupportedOrConvoyedTerritoryId = this.SupportedOrConvoyedTerritory != null ? (int?)this.SupportedOrConvoyedTerritory.Id : null
            };
        }
    }
}
