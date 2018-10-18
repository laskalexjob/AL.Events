using AL.Events.Business.Authentication;
using System.Web;
using System.Web.Mvc;

namespace AL.Events.WEB.RoleAttributes
{
    public class Logged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = HttpContext.Current.User;
            if (user is UserPrincipal)
            {
                return user.Identity.IsAuthenticated;
            }
            return false;
        }
    }
}