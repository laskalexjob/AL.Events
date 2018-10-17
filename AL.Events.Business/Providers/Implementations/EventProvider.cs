using AL.Events.Common.Cache;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using System.Collections.Generic;

namespace AL.Events.Business.Providers.Implementations
{
    class EventProvider : IProvider<Event>
    {
        private readonly IRepository<Event> _repository;
        private readonly IAppCache _cache;

        public EventProvider(IRepository<Event> repository, IAppCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public IReadOnlyCollection<Event> GetAll()
        {
            //_cache.Delete("EventCache");
            //return _repository.GetAll();
            var list = _cache.GetCache("EventCache");
            if (list == null)
            {
                list = _repository.GetAll();
                _cache.Create("EventCache", list, 30);
            }

            return list;
        }

        public Event GetById(int id)
        {
            if (id < 1)
            {
                return null;
            }

            return _repository.GetById(id);
        }
    }
}
