using AL.Events.Business.Authentication;
using AL.Events.WEB.Models;
using AL.Events.WEB.RoleAttributes;
using System;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class LoggingController : Controller
    {
        private readonly ILoginService _loginService;
        public LoggingController(ILoginService loginService)
        {
            if (loginService == null)
            {
                throw new NullReferenceException("loginService");
            }
            _loginService = loginService;
        }

        public ActionResult Login()
        {
            var model = new LoggingViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoggingViewModel model)
        {
            if (ModelState.IsValid)
            {
                _loginService.Login(model.Login, model.Password);

                if (!_loginService.Login(model.Login, model.Password))
                {
                    this.ModelState.AddModelError("", "Login or password is incorrect");
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                this.ModelState.AddModelError("", "Error");
            }
            return View(model);
        }

        [Logged]
        public ActionResult Logout()
        {
            _loginService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}