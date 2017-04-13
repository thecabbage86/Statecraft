using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models
{
    public class Unit
    {
        private Country owner;
        private UnitType unitType;

        public Unit(Country owner, UnitType unitType)
        {
            this.owner = owner;
            this.unitType = unitType;
        }

        public Country Owner { get { return owner; } }

        public UnitType UnitType { get { return unitType; } }
    }
}
