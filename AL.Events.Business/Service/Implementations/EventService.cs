using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;

namespace AL.Events.Business.Service.Implementations
{
    public class EventService : IService<Event>
    {
        private readonly IRepository<Event> _repository;

        public EventService(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public void Create(Event model)
        {
            if (model != null)
            {
                _repository.Create(model);
            }
        }

        public void Save(Event model)
        {
            if (model != null)
            {
                _repository.Update(model);
            }
        }

        public void DeleteById(int Id)
        {
            if (Id > 0)
            {
                _repository.Delete(Id);
            }
        }
    }
}
