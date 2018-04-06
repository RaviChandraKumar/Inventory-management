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
        public readonly IResourceService _resourceService;
        private User CurrentUser;

        public StandardController(IUserService userService, IFacilityService facilityService)
        {
            _userService = userService;
            _facilityService = facilityService;
        }

        public StandardController(IUserService userService)
        {
            _userService = userService;
        }

        public bool IsUserLoggedIn()
        {
            if (Session["userId"] == null)
            {
                return false;
            }
            return true;
        }

        // GET: Standard
        public ActionResult Index()
        {
            if (IsUserLoggedIn())
            {
                return RedirectToAction("UserHome");
            }

            return RedirectToAction("Login");
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
            CurrentUser = _userService.GetByUserName(userViewModel.UserName);
            if (CurrentUser != null)
            {
                var username_from_db = CurrentUser.UserName;
                var password = CurrentUser.PasswordHash;
                if (userViewModel.UserName.Equals(username_from_db) && password.Equals(userViewModel.Password))
                {
                    Session["userId"] = CurrentUser.Id;
                    Session["username"] = CurrentUser.UserName;
                    Session["firstName"] = CurrentUser.FirstName;
                    Session["role"] = CurrentUser.Role;
                    return RedirectToAction("UserHome", CurrentUser);
                }
            }
           

            return RedirectToAction("Login");
        }

        // GET: Standard/Details/5
        public ActionResult UserHome()
        {
            if (IsUserLoggedIn())
            {
                if (CurrentUser == null)
                {
                    CurrentUser = _userService.GetByUserName(Session["username"].ToString());
                }
                var facilities = CurrentUser.Facilities;
                var model = new StandardIndexViewModel(facilities);
                return View("UserHome", model);
            }
            return RedirectToAction("Login");
        }

        // GET:
        public ActionResult MonitorFacility(int id)
        {
            if (IsUserLoggedIn())
            {
                var facility = _facilityService.GetById(id);
                var model = new FacilityViewModel(facility);
                return View("MonitorFacility", model);
            }
            return RedirectToAction("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MonitorFacility(FacilityViewModel facilityViewModel)
        {
            if (IsUserLoggedIn())
            {
                var resources = facilityViewModel.ResourcesAssigned;
                _resourceService.UpdateInventory(resources);
                //return View("MonitorFacility", model);
            }
            return RedirectToAction("Login");
        }
    }
}
