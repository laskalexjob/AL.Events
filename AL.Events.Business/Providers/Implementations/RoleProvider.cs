using System;
using System.Collections.Generic;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;

namespace AL.Events.Business.Providers.Implementations
{
    public class RoleProvider : IProvider<Role>
    {
        private readonly IRepository<Role> _repository;

        public RoleProvider(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            return _repository.GetAll();
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
