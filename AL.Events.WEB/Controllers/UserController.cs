using AL.Events.Business.Providers;
using AL.Events.Business.Service;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AL.Events.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly IService<User> _service;
        private readonly ICustomLogger _logger;
        private readonly IProvider<User> _provider;
        private readonly IProvider<Role> _roleProvider;

        public UserController(IService<User> service, ICustomLogger logger, IProvider<User> provider, IProvider<Role> roleProvider)
        {
            _service = service;
            _logger = logger;
            _provider = provider;
            _roleProvider = roleProvider;
        }

        public ActionResult Index()
        {
            _logger.WriteToLogInfo("Hi from Index action of UserController");

            var businessEntityList = _provider.GetAll();
            var viewModelList = ConvertToListViewModels(businessEntityList);

            return View(viewModelList);
        }

        public ActionResult Create()
        {
            var viewModel = new UserViewModel()
            {
                RoleList = _roleProvider.GetAll()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = ConvertToBusinessModel(viewModel);
                _service.Create(user);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Exception");
            }
            viewModel.RoleList = _roleProvider.GetAll();

            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var businessEntity = _provider.GetById(Id);
            var viewModel = ConvertToViewModel(businessEntity);

            viewModel.RoleList = _roleProvider.GetAll();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel viewModel)
        {
            var user = ConvertToBusinessModel(viewModel);

            try
            {
                _service.Update(user);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("", "Hello from User Controller!");
            }
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            _service.DeleteById(id);

            return RedirectToAction("Index");
        }

        #region Converters
        public List<UserViewModel> ConvertToListViewModels(IEnumerable<User> modelList)
        {
            var resultList = new List<UserViewModel>();
            foreach (User item in modelList)
            {
                resultList.Add(ConvertToViewModel(item));
            }

            return resultList;
        }

        private UserViewModel ConvertToViewModel(User model)
        {
            return new UserViewModel
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Login = model.Login,
                Password = model.Password,
                Email = model.Email,
                Role = model.Role,
                RoleId = model.Role.Id,
                RoleName = model.Role.Name
            };
        }

        private User ConvertToBusinessModel(UserViewModel viewModel)
        {
            var roleList = _roleProvider.GetAll();
            //var role = roleList.Where(c => c.Name == viewModel.RoleName).FirstOrDefault();
            return new User
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                LastName = viewModel.LastName,
                Login = viewModel.Login,
                Password = viewModel.Password,
                Email = viewModel.Email,
                Role = roleList.Where(o => o.Name == viewModel.RoleName).SingleOrDefault()
            };
        }
        #endregion
    }
}