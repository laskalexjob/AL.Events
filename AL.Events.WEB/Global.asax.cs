using AL.Events.Business.Authentication;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.WEB.DependencyResolution;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace AL.Events.WEB
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            XmlConfigurator.Configure();
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie != null)
            {
                var decryptCookie = FormsAuthentication.Decrypt(cookie.Value);
                var user = JsonConvert.DeserializeObject<User>(decryptCookie.UserData);
                HttpContext.Current.User = new UserPrincipal(user);
            }
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            var container = IoC.Initialize();

            var logger = container.GetInstance<ICustomLogger>();

            logger.WriteToLogInfo(exception.Message + " \n " + exception.StackTrace);

            if (exception is HttpException httpException)
            {
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        Response.Redirect("~/Error/NotFound");
                        break;
                    case 500:
                        Response.Redirect("~/Error/ServerError");
                        break;
                    case 401:
                        Response.Redirect("~/Account/Login");
                        break;
                }
            }
        }
    }
}
