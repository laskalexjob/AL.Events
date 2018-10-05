using AL.Events.Business.Service;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.WEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly ICustomLogger _logger;

        public CategoryController(ICategoryService service, ICustomLogger logger)
        {
            _service = service;
            _logger = logger;
        }


        public ActionResult Index()
        {
            _logger.WriteToLogInfo("Hi from Index action of CategoryController");
            var listCategory = _service.GetCategoryList();
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
    }
}