using AL.Events.Common.Logger;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class HomeController : Controller
    {
        private ICustomLogger _customLogger; 

        public HomeController(ICustomLogger myLoger)
        {
            _customLogger = myLoger;
        }

        public ActionResult Index()
        {
            string str = "hi there";

            _customLogger.WriteToLogInfo("God save America!");

            return View(str as object);
        }
    }
}