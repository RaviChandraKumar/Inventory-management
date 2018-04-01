using System;
using System.Linq;
using Biz.Interfaces;
using Core.Domains;
using Data;
using Data.Repositories;

namespace Biz.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepo;

        public ResourceService()
        {
            _resourceRepo = new ResourceRepository();
        }

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepo = resourceRepository;
        }

        public void Delete(Resource resource)
        {
            _resourceRepo.DeleteResource(resource);
        }

        public IQueryable<Resource> GetAll()
        {
            return _resourceRepo.ResourceTable;
        }

        public Resource GetById(int id)
        {
            return _resourceRepo.GetResourceByResourceId(id);
           // throw new System.NotImplementedException();
        }

        public void InsertOrUpdate(Resource resource)
        {
            if (resource.Id == 0)
            {
                DateTime currentdateTime = new DateTime();
                resource.CreatedTimeStamp = currentdateTime;
                resource.LastModifiedTimeStamp = currentdateTime;
                resource.CurrentCount = resource.InitialCount;
                _resourceRepo.InsertNewResourceForExisitingFacility(resource);
            }
            else
            {
                DateTime currentdateTime = new DateTime();
                resource.LastModifiedTimeStamp = currentdateTime;
                _resourceRepo.UpdateResource(resource);
            }
        }

    }


}