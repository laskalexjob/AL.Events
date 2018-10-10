using AL.Events.Business.Providers;
using AL.Events.Business.Service;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.WEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class EventController : Controller
    {
        private readonly IService<Event> _service;
        private readonly ICustomLogger _logger;
        private readonly IProvider<Event> _provider;

        public EventController(IService<Event> service, ICustomLogger logger, IProvider<Event> provider)
        {
            _service = service;
            _logger = logger;
            _provider = provider;
        }
        // GET: Event
        public ActionResult Index()
        {
            _logger.WriteToLogInfo("Hi from Index action of EventController");
            var listCategory = _provider.GetAll();
            var viewModel = ConvertToListViewModel(listCategory);

            return View(viewModel);
        }

        #region Converters
        public List<EventViewModel> ConvertToListViewModel(IEnumerable<Event> modelList)
        {
            List<EventViewModel> resultList = new List<EventViewModel>();
            foreach (Event item in modelList)
            {
                resultList.Add(ConvertToViewModel(item));
            }

            return resultList;
        }

        private EventViewModel ConvertToViewModel(Event model)
        {
            return new EventViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Date = model.Date,
                ImagePath = model.ImagePath,
                Address = model.Address,
                Description = model.Description,
                Location = model.Location,
                Category = new Category
                {
                    Id = model.Category.Id,
                    Name = model.Category.Name
                },
                Organizer = new Organizer
                {
                    Id = model.Organizer.Id,
                    Name = model.Organizer.Name,
                    Email = model.Organizer.Email,
                    Phones = model.Organizer.Phones
                }
            };

        }

        private Event ConvertToBusinessModel(EventViewModel model)
        {
            return new Event
            {
                Id = model.Id,
                Name = model.Name,
                Date = model.Date,
                ImagePath = model.ImagePath,
                Address = model.Address,
                Description = model.Description,
                Location = model.Location,
                Category = new Category
                {
                    Id = model.Category.Id,
                    Name = model.Category.Name
                },
                Organizer = new Organizer
                {
                    Id = model.Organizer.Id,
                    Name = model.Organizer.Name,
                    Email = model.Organizer.Email,
                    Phones = model.Organizer.Phones
                }
            };
        }
        #endregion
    }
}