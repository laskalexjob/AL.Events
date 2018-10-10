using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using System.Collections.Generic;

namespace AL.Events.Business.Providers.Implementations
{
    class EventProvider : IProvider<Event>
    {
        private readonly IRepository<Event> _repository;

        public EventProvider(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<Event> GetAll()
        {
            return _repository.GetAll();
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
