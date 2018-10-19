using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using System.Collections.Generic;

namespace AL.Events.Business.Providers.Implementations
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _repository;

        public UserProvider(IUserRepository repository)
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

        public User GetByLogin(string login)
        {
            return _repository.GetByLogin(login);
        }
    }
}
