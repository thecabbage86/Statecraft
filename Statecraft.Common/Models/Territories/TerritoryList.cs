using Statecraft.Common.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models.Territories
{
    public class TerritoryList : IEnumerable
    {
        //private Hashtable data = new Hashtable();
        private IList<Territory> data = new List<Territory>();

        public virtual Territory this[TerritoryName key]
        {
            get
            {
                return (Territory)data.FirstOrDefault(t => t.Name == key);
            }
        }

        public virtual void Add(Territory n)
        {
            data.Add(n);
        }

        public virtual void Remove(Territory n)
        {
            data.Remove(n);
        }

        public virtual bool ContainsKey(TerritoryName key)
        {
            return data.FirstOrDefault(t => t.Name == key) != null ? true : false;
        }

        public virtual void Clear()
        {
            data.Clear();
        }

        //public virtual List<Territory> Where()
        //{

        //}

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
