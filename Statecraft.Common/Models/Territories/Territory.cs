using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Statecraft.Common.DTOs;

namespace Statecraft.Common.Models.Territories
{
    public class Territory
    {
        private TerritoryName name;
        private bool isSupplyCenter;
        private TerritoryType type;
        private IList<Territory> neighbors;

        public int Id { get; set; }
        public TerritoryName Name { get { return name; } }
        public bool IsSupplyCenter { get { return isSupplyCenter; } }
        public TerritoryType Type { get { return type; } }
        public Unit OccupyingUnit { get; set; }
        public Country? Owner { get; set; }
        public IList<Coast> Coasts { get; set; }
        public IList<Territory> Neighbors { get { return neighbors; } }

        public Territory()
        {
            neighbors = new List<Territory>();
        }

        public Territory(int id, TerritoryName name, bool isSupplyCenter, TerritoryType type, Unit occupyingUnit = null)
        {
            this.Id = id;
            this.name = name;
            this.isSupplyCenter = isSupplyCenter;
            this.type = type;
            this.neighbors = new List<Territory>();
            OccupyingUnit = occupyingUnit;
            if(OccupyingUnit != null)
            {
                Owner = OccupyingUnit.Country;
            }
        }

        public Territory(int id, TerritoryName name, bool isSupplyCenter, TerritoryType type, IList<Coast> coasts) : this(id, name, isSupplyCenter, type, null, coasts){ }

        public Territory(int id, TerritoryName name, bool isSupplyCenter, TerritoryType type, Unit occupyingUnit, IList<Coast> coasts) : this(id, name, isSupplyCenter, type, occupyingUnit)
        {
            this.Coasts = coasts;
        }

        public void AddNeighbor(Territory e)
        {
            neighbors.Add(e);
        }

        public TerritoryDto ToDto(Guid gameId, int gameRoundId)
        {
            return new TerritoryDto()
            {
                Id = this.Id,
                GameId = gameId,
                GameRoundId = gameRoundId,
                OccupyingUnitCountry = this.OccupyingUnit != null ? (Country?)this.OccupyingUnit.Country : null,
                OccupyingUnitType = this.OccupyingUnit != null ? (UnitType?)this.OccupyingUnit.UnitType : null,
                Owner = this.Owner
            };
        }
    }
}
