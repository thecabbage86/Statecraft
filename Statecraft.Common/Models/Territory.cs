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

        public Territory(string name, bool isSupplyCenter)
        {
            this.name = name;
            this.isSupplyCenter = isSupplyCenter;
            this.OccupyingUnit = null;
        }

        public Unit OccupyingUnit { get; set; }
        public string Name { get { return name; }  }
        public bool IsSupplyCenter { get { return isSupplyCenter; } }

	    //adjacent units?
    }
}
