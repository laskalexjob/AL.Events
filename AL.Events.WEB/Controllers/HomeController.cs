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
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Home
        public ActionResult Index()
        {
            log.Error("This is error message from action");
            string str = "hi there";
            return View(str as object);
        }
    }
}