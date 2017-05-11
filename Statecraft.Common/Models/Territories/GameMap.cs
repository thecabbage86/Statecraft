using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models.Territories
{
    public class GameMap
    {
        private IList<Territory> territoryList;


        public GameMap()
        {
            this.territoryList = new List<Territory>();
        }


        public virtual Territory AddTerritory(Territory territory)
        {
            // Make sure the key is unique
            if (!Contains(territory.Name))
            {
                territoryList.Add(territory);
                return territory;
            }
            else
                throw new ArgumentException("There already exists a Territory in the map with name " + territory.Name);
        }
   
        public virtual void AddUndirectedEdge(TerritoryName uKey, TerritoryName vKey)
        {
            AddUndirectedEdge(uKey, vKey, 0);
        }

        public virtual void AddUndirectedEdge(TerritoryName uKey, TerritoryName vKey, int cost)
        {
            // get references to uKey and vKey
            if (Contains(uKey) && Contains(vKey))
                AddUndirectedEdge(territoryList.First(t => t.Name == uKey), territoryList.First( t => t.Name == vKey));
            else
                throw new ArgumentException("One or both of the Territories supplied were not members of the map.");
        }

        public virtual void AddUndirectedEdge(Territory u, Territory v)
        {
            // Make sure u and v are Territorys in this graph
            if (Contains(u.Name) && Contains(v.Name))
            {
                // Add an edge from u -> v and from v -> u
                u.AddNeighbor(v);
                v.AddNeighbor(u);
            }
            else
                // one or both of the Territorys were not found in the graph
                throw new ArgumentException("One or both of the Territories supplied were not members of the map.");
        }

        public virtual bool Contains(Territory n)
        {
            return Contains(n.Name);
        }

        public virtual bool Contains(TerritoryName key)
        {
            return territoryList.FirstOrDefault(t => t.Name == key) != null ? true : false;
        }


        public IList<Territory> Territories
        {
            get
            {
                return this.territoryList;
            }
        }

        //private bool ContainsTerritory(string key)
        //{
        //    return territoryList.FirstOrDefault(t => t.Name == key) != null ? true : false;
        //}
    }
}
