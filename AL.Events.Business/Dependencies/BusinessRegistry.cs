using AL.Events.Business.Service;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using AL.Events.DAL.Repositories.Interfaces;
using StructureMap;

namespace AL.Events.Business.Dependencies
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<ICategoryService>().Use<CategoryService>();
            For<IRepository<Category>>().Use<CategoryRepository>();
        }
    }
}
