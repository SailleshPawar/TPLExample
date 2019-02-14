using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncOverAsync
{
    public class ModernServices
    {
        private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();
        public string GetValueById(int id)
        {
            lock (_cache)
            {
                if(!_cache.TryGetValue(id,out var value))
                {
                    value = Guid.NewGuid().ToString();
                    _cache[id] = value;
                }
                return value; 
            }
        }
    }
}
