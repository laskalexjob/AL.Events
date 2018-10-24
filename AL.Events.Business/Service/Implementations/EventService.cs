using AL.Events.Common.Cache;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace AL.Events.Business.Service.Implementations
{
    public class EventService : IService<Event>
    {
        private readonly IRepository<Event> _repository;
        private readonly IAppCache _cache;

        public EventService(IRepository<Event> repository, IAppCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public void Create(Event model)
        {
            if (model != null)
            {
                _cache.Delete("EventCache");
                _repository.Create(model);
            }
        }

        public void Update(Event model)
        {
            if (model != null)
            {
                SetStatus(model);

                _cache.Delete("EventCache");
                _repository.Update(model);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteById(int Id)
        {
            if (Id > 0)
            {
                _cache.Delete("EventCache");
                _repository.Delete(Id);
            }
        }

        #region StatusLogic
        private IReadOnlyCollection<Event> SetStatuses(IReadOnlyCollection<Event> list)
        {
            foreach (var item in list)
            {
                SetStatus(item);
            }

            return list;
        }

        private Event SetStatus(Event item)
        {
            if (item.Status != EventStatus.Canceled & item.Date > DateTime.Today)
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

            return item;
        }
        #endregion
    }
}
