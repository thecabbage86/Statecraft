using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models.Territories
{
    public class Territory
    {
        private TerritoryName name;
        private bool isSupplyCenter;
        private TerritoryType type;
        private IList<EdgeToNeighbor> neighbors;

        public Territory()
        {
            neighbors = new List<EdgeToNeighbor>();
        }

        public Territory(TerritoryName name, bool isSupplyCenter, TerritoryType type, Unit occupyingUnit = null)
        {
            this.name = name;
            this.isSupplyCenter = isSupplyCenter;
            this.type = type;
            this.neighbors = new List<EdgeToNeighbor>();
            OccupyingUnit = occupyingUnit;
            if(OccupyingUnit != null)
            {
                Owner = OccupyingUnit.Country;
            }
        }

        public Territory(TerritoryName name, bool isSupplyCenter, TerritoryType type, IList<Coast> coasts) : this(name, isSupplyCenter, type, null, coasts){ }

        public Territory(TerritoryName name, bool isSupplyCenter, TerritoryType type, Unit occupyingUnit, IList<Coast> coasts) : this(name, isSupplyCenter, type, occupyingUnit)
        {
            this.Coasts = coasts;
        }

        public TerritoryName Name { get { return name; } }
        public bool IsSupplyCenter { get { return isSupplyCenter; } }
        public TerritoryType Type { get { return type; } }
        public Unit OccupyingUnit { get; set; }
        public Country Owner { get; set; }
        public IList<Coast> Coasts { get; set; }

        protected internal virtual void AddNeighbor(Territory n)
        {
            AddNeighbor(new EdgeToNeighbor(n));
        }

        protected internal virtual void AddNeighbor(Territory n, int cost)
        {
            AddNeighbor(new EdgeToNeighbor(n, cost));
        }

        protected internal virtual void AddNeighbor(EdgeToNeighbor e)
        {
            neighbors.Add(e);
        }
    }
}
