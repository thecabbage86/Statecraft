using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models.Territories
{
    public class Coast
    {
        private Enums.CoastType type;

        public Coast(Enums.CoastType type, bool? isOccupied = null)
        {
            this.type = type;
            this.IsOccupied = isOccupied != null ? (bool)isOccupied : false;
        }

        public Enums.CoastType Type { get { return type; } }
        public bool IsOccupied { get; set; }
    }
}
