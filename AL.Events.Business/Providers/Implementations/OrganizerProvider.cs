using System.Collections.Generic;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;

namespace AL.Events.Business.Providers.Implementations
{
    public class OrganizerProvider : IProvider<Organizer>
    {
        private readonly IRepository<Organizer> _repository;

        public OrganizerProvider(IRepository<Organizer> repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<Organizer> GetAll()
        {
            return _repository.GetAll();
        }

        public Organizer GetById(int id)
        {
            if (id < 1)
            {
                return null;
            }

            return _repository.GetById(id);
        }
    }
}
