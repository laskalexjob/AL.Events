using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;

namespace AL.Events.Business.Service.Implementations
{
    public class OrganizerService : IService<Organizer>
    {
        private readonly IRepository<Organizer> _repository;

        public OrganizerService(IRepository<Organizer> repository)
        {
            _repository = repository;
        }

        public void Create(Organizer model)
        {
            if (model != null)
            {
                _repository.Create(model);
            }
        }

        public void SaveCategory(Organizer model)
        {
            if (model != null)
            {
                _repository.Update(model);
            }
        }

        public void DeleteCategoryById(int Id)
        {
            if (Id > 0)
            {
                _repository.Delete(Id);
            }
        }
    }
}
