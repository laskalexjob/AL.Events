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
            var viewModel = ConvertToListViewModel(listCategory);

            return View(viewModel);
        }

        public List<CategoryViewModel> ConvertToListViewModel(IEnumerable<Category> modelList)
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

        public ActionResult Edit(int Id)
        {
            var categoryBussiness = _provider.GetById(Id);
            var category = ConvertToViewModel(categoryBussiness);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            try
            {
                var category = ConvertToBusinessModelNewCategory(viewModel);
                _service.SaveCategory(category);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("", "Internal Exceptions");
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            if (model.Name != null)
            {
                var category = ConvertToBusinessModelNewCategory(model);
                _service.Create(category);
                return RedirectToAction("Index");
            }
            else
            {
                this.ModelState.AddModelError("", "Internal Exceptions");
            }
            model.CategoryList = _provider.GetAll();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _service.DeleteCategoryById(id);
            return RedirectToAction("Index");
        }

        #region Converters
        private Category ConvertToBusinessModelNewCategory(CategoryViewModel model)
        {
            var category = new Category
            {
                Id = model.Id,
            };

            if (model.NewCategoryName is null)
            {
                category.Name = model.Name;
            }
            else
            {
                category.Name = model.NewCategoryName;
            }

            return category;
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