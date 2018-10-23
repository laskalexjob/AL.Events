using AL.Events.Business.Authentication;
using AL.Events.Business.Providers;
using AL.Events.Business.Service;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL;
using AL.Events.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AL.Events.WEB.ExtentionMethods;
using AL.Events.WEB.RoleAttributes;
using System.IO;

namespace AL.Events.WEB.Controllers
{
    public class EventController : Controller
    {
        private readonly IService<Event> _service;
        private readonly ICustomLogger _logger;
        private readonly IEventProvider _provider;
        private readonly IProvider<Category> _categoryProvider;
        private readonly IProvider<Organizer> _organizerProvider;

        public EventController(IService<Event> service, ICustomLogger logger, IEventProvider provider, IProvider<Category> categoryProvider, IProvider<Organizer> organizerProvider)
        {
            _service = service;
            _logger = logger;
            _provider = provider;
            _categoryProvider = categoryProvider;
            _organizerProvider = organizerProvider;
        }

        [ForUser]
        public ActionResult Index()
        {
            _logger.WriteToLogInfo("Hi from Index action of EventController");

            var user = HttpContext.User.GetCurrentUser();

            var listEvent = _provider.GetByUserId(user.Id);
            var viewModelList = ConvertToListViewModels(listEvent);

            return View(viewModelList);
        }

        [ForEditor]
        public ActionResult EditorIndex()
        {
            _logger.WriteToLogInfo("Hi from EditorIndex action of EventController");

            var listEvent = _provider.GetAll();
            var viewModelList = ConvertToListViewModels(listEvent);

            return View("Index", viewModelList);
        }

        public ActionResult Create()
        {
            var viewModel = new EventViewModel()
            {
                CategoryList = _categoryProvider.GetAll(),
                OrganizerList = _organizerProvider.GetAll(),
                Date = DateTime.Now

            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(EventViewModel viewModel)
        {
            if (viewModel.Date < DateTime.Now)
            {
                this.ModelState.AddModelError("", "Date should be today or in future");

                viewModel.CategoryList = _categoryProvider.GetAll();
                viewModel.OrganizerList = _organizerProvider.GetAll();
                viewModel.Date = DateTime.Now;

                return View(viewModel);
            }

            if (ModelState.IsValid)
            {
                var @event = ConvertToBusinessModel(viewModel);
                @event.Status = EventStatus.Upcoming;
                _service.Create(@event);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Exception");
            }
            viewModel.CategoryList = _categoryProvider.GetAll();
            viewModel.OrganizerList = _organizerProvider.GetAll();

            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var eventBussiness = _provider.GetById(Id);
            var eventViewModel = ConvertToViewModel(eventBussiness);

            eventViewModel.CategoryList = _categoryProvider.GetAll();
            eventViewModel.OrganizerList = _organizerProvider.GetAll();
            eventViewModel.StatusList = new List<EventStatus>
            {
                EventStatus.Passed,
                EventStatus.Going,
                EventStatus.Upcoming,
                EventStatus.Canceled
            };

            return View(eventViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EventViewModel viewModel)
        {
            if (viewModel.Date < DateTime.Now)
            {
                this.ModelState.AddModelError("", "Date should be today or in future");

                viewModel.CategoryList = _categoryProvider.GetAll();
                viewModel.OrganizerList = _organizerProvider.GetAll();
                viewModel.StatusList = new List<EventStatus>
                                                            {
                                                                EventStatus.Passed,
                                                                EventStatus.Going,
                                                                EventStatus.Upcoming,
                                                                EventStatus.Canceled
                                                            };

                return View(viewModel);
            }

            var @event = ConvertToBusinessModel(viewModel);

            try
            {
                _service.Update(@event);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("", "Hello from organizer Controller!");
            }

            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            _service.DeleteById(id);

            return RedirectToAction("Index");
        }

        public JsonResult AddImage()
        {
            string path = null;
            var data = System.Web.HttpContext.Current.Request.Files["imageBrowes"];

            if (data != null)
            {
                path = $"/Content/img/{Path.GetFileName(data.FileName)}";
                data.SaveAs(Server.MapPath(path));
            }

            return Json(new { imagePath = path });
        }

        #region Converters
        public List<EventViewModel> ConvertToListViewModels(IEnumerable<Event> modelList)
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
                CategoryName = model.Category.Name,
                OrganizerName = model.Organizer.Name,
                Status = model.Status,
                UserId = model.UserId
            };
        }

        private Event ConvertToBusinessModel(EventViewModel viewModel)
        {
            var categoryList = _categoryProvider.GetAll();
            var organizerList = _organizerProvider.GetAll();

            var user = HttpContext.User.GetCurrentUser();

            return new Event
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Date = viewModel.Date,
                ImagePath = viewModel.ImagePath ?? DbConstant.Image.DefaultImagePath,
                Address = viewModel.Address,
                Description = viewModel.Description,
                Location = viewModel.Location,
                Status = viewModel.Status,
                Category = categoryList.Where(c => c.Name == viewModel.CategoryName).SingleOrDefault(),
                Organizer = organizerList.Where(o => o.Name == viewModel.OrganizerName).SingleOrDefault(),
                UserId = user.Id
            };
        }
        #endregion
    }
}