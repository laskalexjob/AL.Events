using AL.Events.Business.Providers;
using AL.Events.Business.Service;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Event> _service;
        private readonly ICustomLogger _logger;
        private readonly IProvider<Event> _provider;
        private readonly IProvider<Category> _categoryProvider;
        private readonly IProvider<Organizer> _organizerProvider;


        public HomeController(IService<Event> service, ICustomLogger logger, IProvider<Event> provider, IProvider<Category> categoryProvider, IProvider<Organizer> organizerProvider)
        {
            _service = service;
            _logger = logger;
            _provider = provider;
            _categoryProvider = categoryProvider;
            _organizerProvider = organizerProvider;
        }

        public ActionResult Index()
        {

            _logger.WriteToLogInfo("Hi from Index action of EventController");

            var eventList = _provider.GetAll();
            var viewModelList = ConvertToListViewModels(eventList);

            return View(viewModelList);
        }

        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult CategorySelection()
        {
            var categoryBussiness = _categoryProvider.GetAll();
            var categorys = ConvertToListViewModels(categoryBussiness);
            return PartialView(categorys);
        }

        public ActionResult NavigationIndex(int id)
        {
            IEnumerable<Event> eventsList = _provider.GetAll();
            if (id != 0)
            {
                eventsList = eventsList.Where(e => e.Category.Id == id);

                IEnumerable<EventViewModel> list = ConvertToListViewModels(eventsList);
                return View("Index", list);


            }
            IEnumerable<EventViewModel> list2 = ConvertToListViewModels(eventsList);
            return View("Index", eventsList);
        }

        #region Converters
        //Event
        public List<EventViewModel> ConvertToListViewModels(IEnumerable<Event> modelList)
        {
            List<EventViewModel> resultList = new List<EventViewModel>();

            var categoryList = _categoryProvider.GetAll();

            foreach (Event item in modelList)
            {
                var @event = ConvertToViewModel(item);
                @event.CategoryList = categoryList;
                resultList.Add(@event);
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
                CategoryName = model.Category.Name,
                OrganizerName = model.Organizer.Name,
                CategoryId = model.Category.Id,
                Status = model.Status
            };
        }

        public List<CategoryViewModel> ConvertToListViewModels(IEnumerable<Category> modelList)
        {
            List<CategoryViewModel> resultList = new List<CategoryViewModel>();
            foreach (Category item in modelList)
            {
                resultList.Add(new CategoryViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            return resultList;
        }
        //Category
        private Category ConvertToBusinessModelNewCategory(CategoryViewModel model)
        {
            return new Category
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        private CategoryViewModel ConvertToViewModel(Category categoryBussiness)
        {
            return new CategoryViewModel
            {
                Id = categoryBussiness.Id,
                Name = categoryBussiness.Name,
            };
        }
        #endregion
    }
}