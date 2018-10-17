using AL.Events.Common.Cache;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;

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
                _cache.Delete("EventCache");
                _repository.Update(model);
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
    }
}
