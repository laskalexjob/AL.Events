using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL.Repositories;
using AL.Events.DAL.Repositories.Interfaces;
using StructureMap;

namespace AL.Events.DAL.Dependencies
{
    public class DALRegistry : Registry
    {
        public DALRegistry()
        {
            For<ICustomLogger>().Use<CustomLogger>();
            For<IRepository<Category>>().Use<CategoryRepository>();
        }
    }
}
