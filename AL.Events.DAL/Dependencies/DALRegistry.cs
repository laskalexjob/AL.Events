using AL.Events.Common.Entities;
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
            For<IRepository<Category>>().Use<CategoryRepository>();
            For<IRepository<Event>>().Use<EventRepository>();
            For<IEventRepository>().Use<EventRepository>();
            For<IRepository<Organizer>>().Use<OrganizerRepository>();
            For<IUserRepository>().Use<UserRepository>();
            For<IRepository<User>>().Use<UserRepository>();
            For<IRepository<Role>>().Use<RoleRepository>();

            For<IConnectionManager>().Use<ConnectionManager>();

            For<ISqlFactory>().Use<SqlFactory>();
        }
    }
}
