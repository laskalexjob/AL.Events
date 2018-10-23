using AL.Events.Business.Authentication;
using AL.Events.Business.Providers;
using AL.Events.Business.Providers.Implementations;
using AL.Events.Business.Service;
using AL.Events.Business.Service.Implementations;
using AL.Events.Common.Entities;
using StructureMap;

namespace AL.Events.Business.Dependencies
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IService<Category>>().Use<CategoryService>();
            For<IService<Event>>().Use<EventService>();
            For<IService<Organizer>>().Use<OrganizerService>();
            For<IService<User>>().Use<UserService>();

            For<ILoginService>().Use<LoginService>();

            For<IProvider<Category>>().Use<CategoryProvider>();
            For<IProvider<Event>>().Use<EventProvider>();
            For<IProvider<Organizer>>().Use<OrganizerProvider>();
            For<IProvider<User>>().Use<UserProvider>();
            For<IProvider<Role>>().Use<RoleProvider>();
            For<IProvider<AdCommon>>().Use<AdsProvider>();

            For<IAdsProvider>().Use<AdsProvider>();
            For<IUserProvider>().Use<UserProvider>();
            For<IEventProvider>().Use<EventProvider>();
        }
    }
}
