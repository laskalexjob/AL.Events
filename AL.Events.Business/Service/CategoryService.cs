﻿using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Events.Business.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Category GetCategory(int id)
        {
            if (id < 1)
            {
                return null;
            }

            return _repository.GetById(id);
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return _repository.GetAll();
        }

        public void Create(Category model)
        {
            if (model != null)
            {
                _repository.Create(model);
            }
        }

        public void SaveCategory(Category model)
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
