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
        private Country country;
        private UnitType unitType;

        public Unit(Country country, UnitType unitType)
        {
            this.country = country;
            this.unitType = unitType;
        }

        public Country Country { get { return country; } }

        public UnitType UnitType { get { return unitType; } }
    }
}
