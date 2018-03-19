using System.Linq;
using Biz.Interfaces;
using Core.Domains;
using Data;
namespace Biz.Services
{
    public class AssetService : IAssetService
    {
        private readonly IRepository<Asset> _assetRepo;

        public AssetService()
        {
            _assetRepo = new Repository<Asset>();
        }

        public void Delete(Asset asset)
        {
            _assetRepo.Delete(asset);
        }

        public IQueryable<Asset> GetAll()
        {
            return _assetRepo.Table;
        }

        public Asset GetById(int id)
        {
            return _assetRepo.GetById(id);
           // throw new System.NotImplementedException();
        }

        public void InsertOrUpdate(Asset asset)
        {
            if (asset.Id == 0)
            {
                _assetRepo.Insert(asset);
            }
            else
            {
                _assetRepo.Update(asset);
            }
        }
    }


}