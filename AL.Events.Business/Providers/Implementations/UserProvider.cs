using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using System.Collections.Generic;

namespace AL.Events.Business.Providers.Implementations
{
    public class UserProvider : IProvider<User>
    {
        private readonly IRepository<User> _repository;

        public UserProvider(IRepository<User> repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            if (id < 1)
            {
                return null;
            }

            return _repository.GetById(id);
        }
    }
}
