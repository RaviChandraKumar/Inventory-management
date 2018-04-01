using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StandardController : Controller
    {
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



        // GET: Standard/Details/5
        public ActionResult UserHome(string userName)
        {

            return View();
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

        // GET: Standard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
