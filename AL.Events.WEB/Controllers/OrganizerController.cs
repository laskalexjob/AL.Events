using AL.Events.Business.Providers;
using AL.Events.Business.Service;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.WEB.Models;
using System;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var organizer = ConvertToBusinessModel(model);
                _service.Create(organizer);
                return RedirectToAction("Index");
            }
            else
            {
                this.ModelState.AddModelError("", "Hello from Controller!");
            }

            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var categoryBussiness = _provider.GetById(Id);
            var category = new OrganizerViewModel()
            {
                Id = categoryBussiness.Id,
                Name = categoryBussiness.Name,
                Email = categoryBussiness.Email,
                Phones = categoryBussiness.Phones
            };

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(OrganizerViewModel viewModel)
        {
            var category = ConvertToBusinessModel(viewModel);

            try
            {
                _service.Update(category);
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

        private Organizer ConvertToBusinessModel(OrganizerViewModel model)
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