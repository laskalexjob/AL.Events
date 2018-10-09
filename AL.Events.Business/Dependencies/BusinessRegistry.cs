using AL.Events.Business.Providers;
using AL.Events.Business.Providers.Implementations;
using AL.Events.Business.Service;
using AL.Events.Business.Service.Implementations;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using AL.Events.DAL.Repositories.Implementations;
using StructureMap;

namespace AL.Events.Business.Dependencies
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IService<Category>>().Use<CategoryService>();
            For<IRepository<Category>>().Use<CategoryRepository>();
            For<IProvider<Category>>().Use<CategoryProvider>();
        }
    }
}
