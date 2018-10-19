using AL.Events.Common.Entities;
using System.Security.Principal;

namespace AL.Events.Business.Authentication
{
    public class UserPrincipal : IPrincipal
    {
        public UserPrincipal(User user)
        {
            Identity = new GenericIdentity(user.Login);
            User = user;
        }

        public IIdentity Identity { get; private set; }

        public User User { get; set; }

        public bool IsInRole(string role)
        {
            return User.Role.Name.Contains(role);
        }
        
    }

    public static class UserPrincipalUtils
    {
        public static User GetCurrentUser(this UserPrincipal user)
        {
            return user.User as User;
        }
    }
}
