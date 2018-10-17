using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;

namespace AL.Events.Business.Service.Implementations
{
    public class UserService : IService<User>
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Create(User model)
        {
            if (model != null)
            {
                _repository.Create(model);
            }
        }

        public void Update(User model)
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
