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

        public Territory(string name)
        {
            this.name = name;
            this.OccupyingUnit = null;
        }

        public Unit OccupyingUnit { get; set; }
        public string Name { get { return name; }  }
	    //adjacent units?
    }
}
