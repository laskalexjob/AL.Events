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
    public class CategoryController : Controller
    {
        private readonly IService<Category> _service;
        private readonly ICustomLogger _logger;
        private readonly IProvider<Category> _provider;

        public CategoryController(IService<Category> service, ICustomLogger logger, IProvider<Category> provider)
        {
            _service = service;
            _logger = logger;
            _provider = provider;
        }


        public ActionResult Index()
        {
            _logger.WriteToLogInfo("Hi from Index action of CategoryController");
            var listCategory = _provider.GetAll();
            var viewModel = ConvertToListViewModels(listCategory);

            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var categoryBussiness = _provider.GetById(Id);
            var category = ConvertToViewModel(categoryBussiness);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            var category = ConvertToBusinessModelNewCategory(viewModel);

            try
            {
                _service.Update(category);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("", "Hello from Controller!");
            }
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = ConvertToBusinessModelNewCategory(model);
                _service.Create(category);
                return RedirectToAction("Index");
            }
            else
            {
                this.ModelState.AddModelError("", "Hello from Controller!");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _service.DeleteById(id);

            return RedirectToAction("Index");
        }

        #region Converters
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