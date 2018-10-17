using AL.Events.Common.Entities;
using System.Collections.Generic;

namespace AL.Events.Common.Cache
{
    public interface IAppCache
    {
        bool Create(string key, IReadOnlyCollection<Event> item, int minutes);
        void Delete(string key);
        IReadOnlyCollection<Event> GetCache(string key);
        void Update(string key, IReadOnlyCollection<Event> item, int minutes);
    }
}
