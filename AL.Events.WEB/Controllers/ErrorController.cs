using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult NotFound()
        {
            return View();
        }

        public ActionResult ServerError()
        {
            return View();
        }
    }
}