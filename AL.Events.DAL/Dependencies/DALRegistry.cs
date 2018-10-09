using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL.Infrastructure.Core;
using AL.Events.DAL.Infrastructure.Core.Implementations;
using AL.Events.DAL.Infrastructure.Factories;
using AL.Events.DAL.Infrastructure.Factories.Implementations;
using AL.Events.DAL.Repositories;
using AL.Events.DAL.Repositories.Implementations;
using StructureMap;

namespace AL.Events.DAL.Dependencies
{
    public class DALRegistry : Registry
    {
        public DALRegistry()
        {
            For<ICustomLogger>().Use<CustomLogger>();
            For<IRepository<Category>>().Use<CategoryRepository>();
            For<IConnectionManager>().Use<ConnectionManager>();
            For<ISqlFactory>().Use<SqlFactory>();
        }
    }
}
