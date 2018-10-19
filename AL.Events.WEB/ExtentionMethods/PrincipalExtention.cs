using AL.Events.Business.Providers;
using AL.Events.Common.Entities;
using AL.Events.WEB.DependencyResolution;
using System.Security.Principal;
using System.Web;

namespace AL.Events.WEB.ExtentionMethods
{
    public static class PrincipalExtention
    {
        private static readonly IUserProvider _userProvider;
        private static User _user;

        static PrincipalExtention()
        {
            var container = IoC.Initialize();

            _userProvider = container.GetInstance<IUserProvider>();
        }

        public static User GetCurrentUser(this IPrincipal principal)
        {
            _user = _userProvider.GetByLogin(HttpContext.Current.User.Identity.Name);

            return _user;
        }
    }
}