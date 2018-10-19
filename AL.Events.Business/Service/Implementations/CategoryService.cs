using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;

namespace AL.Events.Business.Service.Implementations
{
    public class CategoryService : IService<Category>
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public void Create(Category model)
        {
            if (model != null)
            {
                _repository.Create(model);
            }
        }
        
        public void Update(Category model)
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
