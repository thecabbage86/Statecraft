using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models
{
    public class Territory
    {
        private string name;
        private bool isSupplyCenter;
        private TerritoryType type;

        public Territory()
        {

        }

        public Territory(string name, bool isSupplyCenter, TerritoryType type, Unit occupyingUnit = null)
        {
            this.name = name;
            this.isSupplyCenter = isSupplyCenter;
            this.type = type;
            OccupyingUnit = occupyingUnit;
            if(OccupyingUnit != null)
            {
                Owner = OccupyingUnit.Country;
            }
        }

        public Territory(string name, bool isSupplyCenter, TerritoryType type, IList<Coast> coasts) : this(name, isSupplyCenter, type, null, coasts){ }

        public Territory(string name, bool isSupplyCenter, TerritoryType type, Unit occupyingUnit, IList<Coast> coasts) : this(name, isSupplyCenter, type, occupyingUnit)
        {
            this.Coasts = coasts;
        }

        public string Name { get { return name; } }
        public bool IsSupplyCenter { get { return isSupplyCenter; } }
        public TerritoryType Type { get { return type; } }
        public Unit OccupyingUnit { get; set; }
        public Country Owner { get; set; }
        public IList<Coast> Coasts { get; set; }

	    //adjacent territories?
    }
}
