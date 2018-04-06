using System;
using System.Web.Mvc;
using Web.ViewModels;
using Biz.Interfaces;
using Core.Domains;
using System.Linq;

namespace Web.Controllers
{
    public class ResourceController : Controller
    
    {
        public readonly IResourceService _resourceService;
        public readonly IFacilityService _facilityService;

        public ResourceController(IResourceService resService, IFacilityService facilityService)
        {
            _resourceService = resService;
            _facilityService = facilityService;
        }

        public ResourceController(IResourceService resourceService)
        {
            
            _resourceService = resourceService;
        }

        // GET: Resource/Details/5
        public ActionResult ResourceList()
        {
            try
            {
                var resourceList = _resourceService.GetAll();
                var model = new StandardIndexViewModel(resourceList);
                return View("ResourceList", model);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        public ActionResult InactiveResourceList()
        {
            try
            {
                var resourceList = _resourceService.GetAllInactive();
                var model = new StandardIndexViewModel(resourceList);
                return View("ResourceList", model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            var facilities = _facilityService.GetAll();
            var model = new ResourceViewModel
            {
                ListOfAllFacilities = facilities.ToList()
            };
            return View("Create", model);
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(ResourceViewModel resourceViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resource = new Resource()
                    {
                        Name = resourceViewModel.Name,
                        Description = resourceViewModel.Description,
                        InitialCount = resourceViewModel.InitCount,
                        IsActive = resourceViewModel.IsActive,
                        FacilityId = resourceViewModel.FacilityId
                    };

                    _resourceService.InsertOrUpdate(resource);
                    return RedirectToAction("ResourceList");
                    //return View("ResourceList", model);
                }
            }
            catch(Exception e)
            {
                Console.Write(e);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            var resource = _resourceService.GetById(id);
            if (resource == null)
            {
                return HttpNotFound();
            }

            var model = new ResourceViewModel(resource);
            model.ListOfAllFacilities = _facilityService.GetAll().ToList();
            return View("Edit", model);
            //return View();
        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ResourceViewModel model)
        {
            try
            {
                var resource = new Resource()
                {
                    Id = model.Id,
                    Name = model.Name,
                    InitialCount = model.InitCount,
                    CurrentCount = model.CurrentCount,
                    Comment = model.Comment,
                    Description = model.Description,
                    IsActive = model.IsActive,
                    FacilityId = model.FacilityId
                };
                // TODO: Add update logic here
                _resourceService.InsertOrUpdate(resource);

                return RedirectToAction("ResourceList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var resource = _resourceService.GetById(id);
                var model = new ResourceViewModel(resource);
                Console.WriteLine(model.Name);
                return View("Delete", model);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        // POST: Resource/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ResourceViewModel model)
        {
            try
            {
                var resource = _resourceService.GetById(id);
                _resourceService.Delete(resource);
            }
            catch (Exception e)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("ResourceList");
            }
            return RedirectToAction("ResourceList");
        }
    
    }
}
