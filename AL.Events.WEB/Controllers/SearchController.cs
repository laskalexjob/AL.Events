using AL.Events.Business.Providers;
using AL.Events.Common.Entities;
using AL.Events.DAL;
using AL.Events.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProvider<Event> _provider;
        private readonly IProvider<Category> _categoryProvider;
        private readonly IProvider<Organizer> _organizerProvider;

        public SearchController(IProvider<Event> provider, IProvider<Category> categoryProvider, IProvider<Organizer> organizerProvider)
        {
            _provider = provider;
            _categoryProvider = categoryProvider;
            _organizerProvider = organizerProvider;
        }

        public ActionResult Index()
        {
            var listEvent = _provider.GetAll();
            var viewModelList = ConvertToListViewModels(listEvent);
            viewModelList.First().CategoryList = _categoryProvider.GetAll();
            viewModelList.First().StatusList = new List<EventStatus>
            {
                EventStatus.Passed,
                EventStatus.Going,
                EventStatus.Upcoming,
                EventStatus.Canceled
            };

            return View(viewModelList);
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
                Status = model.Status
            };
        }

        private Event ConvertToBusinessModel(EventViewModel viewModel)
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
                Status = viewModel.Status,
                Category = categoryList.Where(c => c.Name == viewModel.CategoryName).SingleOrDefault(),
                Organizer = organizerList.Where(o => o.Name == viewModel.OrganizerName).SingleOrDefault()
            };
        }
        #endregion
    }
}