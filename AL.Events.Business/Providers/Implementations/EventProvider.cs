using AL.Events.Common.Cache;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace AL.Events.Business.Providers.Implementations
{
    class EventProvider : IEventProvider
    {
        private readonly IEventRepository _repository;
        private readonly IAppCache _cache;

        public EventProvider(IEventRepository repository, IAppCache cache)
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

                SetStatuses(list);
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

        public IReadOnlyCollection<Event> GetByUserId(int id)
        {
            var list = _repository.GetByUserId(id);

            SetStatuses(list);

            return list;
        }

        private IReadOnlyCollection<Event> SetStatuses(IReadOnlyCollection<Event> list)
        {
            foreach (var item in list)
            {
                if (item.Status != EventStatus.Canceled & item.Date > DateTime.Now)
                {
                    item.Status = EventStatus.Upcoming;
                }
                else if (item.Date == DateTime.Today)
                {
                    item.Status = EventStatus.Going;
                }
                else
                {
                    item.Status = EventStatus.Passed;
                }
            }

            return list;
        }
    }
}
