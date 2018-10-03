using AL.Events.Common.Logger;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class HomeController : Controller
    {
        private ICustomLogger _customLogger; 
        // GET: Home

        public HomeController(ICustomLogger myLoger)
        {
            try
            {
                _customLogger = myLoger;
            }
            catch (NullReferenceException)
            {
                View("Index", "Error");
            }
        }

        public HomeController()
        {
            _customLogger = new CustomLogger();
        }

        public ActionResult Index()
        {
            string str = "hi there";

            _customLogger.WriteToLogInfo("God save America!");

            return View(str as object);


            // return Content("serial".ToUpper());
        }
    }
}