using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace AL.Events.Business.Providers.Implementations
{
    public class CategoryProvider : IProvider<Category>
    {
        private readonly IRepository<Category> _repository;

        public CategoryProvider(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
            if (id < 1)
            {
                return null;
            }

            return _repository.GetById(id);
        }
    }
}
