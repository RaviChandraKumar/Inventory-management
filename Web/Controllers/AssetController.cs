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
    public class AssetController : Controller
    
    {
        public readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }

        // GET: Asset/Details/5
        public ActionResult AssetList()
        {
            try
            {
                var assetList = _assetService.GetAll();
                var model = new StandardIndexViewModel(assetList);
                return View("AssetList", model);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asset/Create
        [HttpPost]
        public ActionResult Create(AssetViewModel assetViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var asset = new Asset()
                    {
                        Name = assetViewModel.Name,
                        Description = assetViewModel.Description,
                        InitCount = assetViewModel.InitCount
                    };

                    _assetService.InsertOrUpdate(asset);
                    return RedirectToAction("AssetList");
                    //return View("AssetList", model);
                }
            }
            catch(Exception e)
            {
                Console.Write(e);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }

        // GET: Asset/Edit/5
        public ActionResult Edit(int id)
        {
            var asset = _assetService.GetById(id);
            if (asset == null)
            {
                return HttpNotFound();
            }

            var model = new AssetViewModel(asset);
            //Console.WriteLine(model.UserName);
            return View("Edit", model);
            //return View();
        }

        // POST: Asset/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AssetViewModel model)
        {
            try
            {
                var asset = new Asset()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    IsActive = model.IsActive,
                };
                // TODO: Add update logic here
                _assetService.InsertOrUpdate(asset);

                return RedirectToAction("AssetList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Asset/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var asset = _assetService.GetById(id);
                var model = new AssetViewModel(asset);
                Console.WriteLine(model.Name);
                return View("Delete", model);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        // POST: Asset/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AssetViewModel model)
        {
            try
            {
                var asset = _assetService.GetById(id);
                _assetService.Delete(asset);
            }
            catch (Exception e)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("AssetList");
            }
            return RedirectToAction("AssetList");
        }
    
    }
}
