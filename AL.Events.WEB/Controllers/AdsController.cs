using AL.Events.Business.Providers;
using AL.Events.WEB.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class AdsController : Controller
    {
        private readonly IAdsProvider _provider;

        public AdsController(IAdsProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetRandomAdverts()
        {
            var list = _provider.GetRandomAds();
            var parsedList = new List<AdViewModel>();

            if (list == null)
            {
                parsedList.Add(new AdViewModel()
                {
                    Description  = "Here might be your ads!",
                    Link = "https://apple.com"
                });

                return View(parsedList);
            }

            foreach (var item in list)
            {
                parsedList.Add(new AdViewModel()
                {
                    Id = item.Id,
                    Link = item.Link,
                    Description = item.Description,
                    Image = Convert.ToBase64String(item.Image)
                });
            }

            return View(parsedList);
        }
    }
}