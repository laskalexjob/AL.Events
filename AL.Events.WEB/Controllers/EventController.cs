﻿using AL.Events.Business.Providers;
using AL.Events.Business.Service;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL;
using AL.Events.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class EventController : Controller
    {
        private readonly IService<Event> _service;
        private readonly ICustomLogger _logger;
        private readonly IProvider<Event> _provider;
        private readonly IProvider<Category> _categoryProvider;
        private readonly IProvider<Organizer> _organizerProvider;

        public EventController(IService<Event> service, ICustomLogger logger, IProvider<Event> provider, IProvider<Category> categoryProvider, IProvider<Organizer> organizerProvider)
        {
            _service = service;
            _logger = logger;
            _provider = provider;
            _categoryProvider = categoryProvider;
            _organizerProvider = organizerProvider;
        }
        // GET: Event
        public ActionResult Index()
        {
            _logger.WriteToLogInfo("Hi from Index action of EventController");
            var listCategory = _provider.GetAll();
            var viewModelList = ConvertToListViewModels(listCategory);

            return View(viewModelList);
        }

        public ActionResult Create()
        {
            var viewModel = new EventViewModel()
            {
                CategoryList = _categoryProvider.GetAll(),
                OrganizerList = _organizerProvider.GetAll()
            };
            

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(EventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var @event = ConvertToBusinessModelForCreate(viewModel);
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

        public ActionResult Delete(int id)
        {
            _service.DeleteById(id);

            return RedirectToAction("Index");
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
            };

        }

        private Event ConvertToBusinessModelForCreate(EventViewModel viewModel)
        {
            var categoryList = _categoryProvider.GetAll();
            var organizerList = _organizerProvider.GetAll();
            var category = categoryList.Where(c => c.Name == viewModel.CategoryName).FirstOrDefault();
            var organizer = organizerList.Where(c => c.Name == viewModel.OrganizerName).FirstOrDefault();
            return new Event
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Date = viewModel.Date,
                ImagePath = viewModel.ImagePath ?? DbConstant.Image.DefaultImagePath,
                Address = viewModel.Address,
                Description = viewModel.Description,
                Location = viewModel.Location,
                Category = categoryList.Where(c => c.Name == viewModel.CategoryName).SingleOrDefault(),
                Organizer = organizerList.Where(o => o.Name == viewModel.OrganizerName).SingleOrDefault()
            };
        }
        #endregion
    }
}