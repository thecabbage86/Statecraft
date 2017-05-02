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

        //public virtual void AddTerritory(Territory n)
        //{
        //    // Make sure this Territory is unique
        //    if (!territoryList.ContainsKey(n.Name))
        //        territoryList.Add(n);
        //    else
        //        throw new ArgumentException("There already exists a Territory in the map with name " + n.Name);
        //}
   
        public virtual void AddUndirectedEdge(string uKey, string vKey)
        {
            AddUndirectedEdge(uKey, vKey, 0);
        }

        public virtual void AddUndirectedEdge(string uKey, string vKey, int cost)
        {
            // get references to uKey and vKey
            if (Contains(uKey) && Contains(vKey))
                AddUndirectedEdge(territoryList.First(t => t.Name == uKey), territoryList.First( t => t.Name == vKey), cost);
            else
                throw new ArgumentException("One or both of the Territories supplied were not members of the map.");
        }

        public virtual void AddUndirectedEdge(Territory u, Territory v)
        {
            AddUndirectedEdge(u, v, 0);
        }

        public virtual void AddUndirectedEdge(Territory u, Territory v, int cost)
        {
            // Make sure u and v are Territorys in this graph
            if (Contains(u.Name) && Contains(v.Name))
            {
                // Add an edge from u -> v and from v -> u
                u.AddNeighbor(v, cost);
                v.AddNeighbor(u, cost);
            }
            else
                // one or both of the Territorys were not found in the graph
                throw new ArgumentException("One or both of the Territories supplied were not members of the map.");
        }

        public virtual bool Contains(Territory n)
        {
            return Contains(n.Name);
        }

        public virtual bool Contains(string key)
        {
            return territoryList.FirstOrDefault(t => t.Name == key) != null ? true : false;
        }


        public virtual IList<Territory> Territories
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
