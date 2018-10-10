using AL.Events.Business.Providers;
using AL.Events.Business.Service;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.WEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly IService<Organizer> _service;
        private readonly ICustomLogger _logger;
        private readonly IProvider<Organizer> _provider;

        public OrganizerController(IService<Organizer> service, ICustomLogger logger, IProvider<Organizer> provider)
        {
            _service = service;
            _logger = logger;
            _provider = provider;
        }


        public ActionResult Index()
        {
            _logger.WriteToLogInfo("Hi from Index action of OrganizerController");

            var listOrganizer = _provider.GetAll();
            var viewModelList = ConvertToListViewModel(listOrganizer);

            return View(viewModelList);
        }

        #region Converters
        public List<OrganizerViewModel> ConvertToListViewModel(IEnumerable<Organizer> modelList)
        {
            List<OrganizerViewModel> resultList = new List<OrganizerViewModel>();
            foreach (Organizer item in modelList)
            {
                resultList.Add(new OrganizerViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Phones = item.Phones
                });
            }
            return resultList;
        }

        private Organizer ConvertToBusinessModelNewOrganizer(OrganizerViewModel model)
        {
            return new Organizer
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phones = model.Phones
            };
        }
        #endregion
    }
}