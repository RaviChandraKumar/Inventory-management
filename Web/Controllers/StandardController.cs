using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;
using Core.Domains;
using Biz.Interfaces;

namespace Web.Controllers
{
    public class StandardController : Controller
    {
        public readonly IUserService _userService;
        public readonly IFacilityService _facilityService;

        public StandardController(IUserService userService, IFacilityService facilityService)
        {
            _userService = userService;
            _facilityService = facilityService;
        }

        public StandardController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Standard
        public ActionResult Index()
        {
            //if (userIsLoggedIn)
            //{
            //    return RedirectToAction("UserHome", emailId);
            //}
            return View("UserLogin");
        }
        
        public ActionResult Login()
        {
            //if (userIsLoggedIn)
            //{
            //    return RedirectToAction("UserHome", emailId);
            //}
            return View("UserLogin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userViewModel)
        {
            var users = _userService.GetByUserName(userViewModel.UserName);
            //var model = new StandardIndexViewModel(users);
            //return View("UserList", model);
            var username_from_db = users.UserName;
            var password = users.PasswordHash;
            if (userViewModel.UserName == username_from_db)
            {
                if (password == userViewModel.Password)
                {
                    Session["id"] = users.Id;
                    Session["username"] = users.UserName;
                    Session["password"] = users.PasswordHash;
                    Session["facility"] = users.Facilities;
                    Session["role"] = users.Role;
                    return View("UserHome");
                }
                else
                {
                    return View("UserLogin");
                }
            }
            else
            {
                return View("UserLogin");
            }
        }

        // GET: Standard/Details/5
        public ActionResult UserHome(string userName)
        {

            return View("FacilityList");
        }

        // GET: Standard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Standard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // POST: Standard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Standard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Standard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
