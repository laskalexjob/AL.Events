using AL.Events.Common.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace AL.Events.Common.Cache
{
    public class EventCache : IAppCache
    {
        private MemoryCache _cache;

        public EventCache()
        {
            _cache = new MemoryCache("ApplicationCache");
        }

        public bool Create(string key, IReadOnlyCollection<Event> item, int minutes)
        {
            if (item == null)
            {
                return false;
            }

            var result = _cache.Add(key, item, DateTime.Now.AddMinutes(minutes));

            return result;
        }

        public void Delete(string key)
        {
            if (_cache.Contains(key))
            {
                _cache.Remove(key);
            }
        }

        public IReadOnlyCollection<Event> GetCache(string key)
        {
            var cache = _cache.Get(key);

            var items = cache as IReadOnlyCollection<Event>;

            return items;
        }

        public void Update(string key, IReadOnlyCollection<Event> item, int minutes)
        {
            if (item == null)
            {
                return;
            }

            _cache.Set(key, item, DateTime.Now.AddMinutes(minutes));
        }
    }
}
