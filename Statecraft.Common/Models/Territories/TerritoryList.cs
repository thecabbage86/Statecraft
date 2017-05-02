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
        private Hashtable data = new Hashtable();

        public virtual Territory this[string key]
        {
            get
            {
                return (Territory)data[key];
            }
        }

        public virtual void Add(Territory n)
        {
            data.Add(n.Name, n);
        }

        public virtual void Remove(Territory n)
        {
            data.Remove(n.Name);
        }

        public virtual bool ContainsKey(string key)
        {
            return data.ContainsKey(key);
        }

        public virtual void Clear()
        {
            data.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
