using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;
using Biz.Interfaces;
using Core.Domains;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserService _userService;
        public readonly IFacilityService _facilityService;

        public UserController(IUserService userService,IFacilityService facilityService)
        {
            _userService = userService;
            _facilityService = facilityService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult UserList()
        {
            var users = _userService.GetAll();
            var model = new StandardIndexViewModel(users);
            return View("UserList", model);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult CreateUser()
        {
            var facilities = _facilityService.GetAll();
            var model = new UserViewModel {
            ListOfAllFacilities = facilities.ToList()
            };
            return View("CreateUser", model);
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(UserViewModel userViewModel)
        public ActionResult Create(UserViewModel userViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var user = new User()
                    {
                        Id = userViewModel.Id,
                        EmailId = userViewModel.EmailId,
                        IsActive = userViewModel.IsActive,
                        PasswordHash = Guid.NewGuid().ToString("d").Substring(1, 8),
                        FacilityId = userViewModel.FacilityId
                    };

                    _userService.InsertOrUpdate(user);
                    
                    return RedirectToAction("UserList");
                }
            }
            catch(Exception e)
            {
                Console.Write(e.StackTrace);
                        IsActive = true,
                        PasswordHash = Guid.NewGuid().ToString("d").Substring(1, 8)
                    };

                    _userService.InsertOrUpdate(user);
                    return RedirectToAction("UserList");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var model = new UserViewModel(user);

            return View("Edit", model);
            //return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel model)
        {
            try
            {

                var user = _userService.GetById(id);
                user.Id = model.Id;
                user.EmailId = model.EmailId;
                user.IsActive = model.IsActive;
                var user = new User()
                {
                    Id = model.Id,
                    EmailId = model.EmailId,
                    IsActive = model.IsActive,
                };
                // TODO: Add update logic here
                _userService.InsertOrUpdate(user);

                return RedirectToAction("UserList");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("UserList");
            }
            catch
            {
                return View();
            }
        }
    }
}
