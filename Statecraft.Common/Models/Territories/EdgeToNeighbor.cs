using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models.Territories
{
    public class EdgeToNeighbor
    {
        // private member variables
        private int cost;
        private Territory neighbor;

        public EdgeToNeighbor(Territory neighbor) : this(neighbor, 0) { }

        public EdgeToNeighbor(Territory neighbor, int cost)
        {
            this.cost = cost;
            this.neighbor = neighbor;
        }

        public virtual int Cost
        {
            get
            {
                return cost;
            }
        }

        public virtual Territory Neighbor
        {
            get
            {
                return neighbor;
            }
        }
    }

    public class AdjacencyList : CollectionBase
    {
        protected internal virtual void Add(EdgeToNeighbor e)
        {
            base.InnerList.Add(e);
        }

        public virtual EdgeToNeighbor this[int index]
        {
            get { return (EdgeToNeighbor)base.InnerList[index]; }
            set { base.InnerList[index] = value; }
        }
    }
}
