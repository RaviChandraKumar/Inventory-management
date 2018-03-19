using System.Linq;
using Core.Domains;

namespace Biz.Interfaces
{
    public interface IAssetService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<Asset> GetAll();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Asset GetById(int id);

        //User GetByEmailId(string id);

        /// <summary>
        /// Inserts or updates the model.
        /// </summary>
        /// <param name="account">The account.</param>
        void InsertOrUpdate(Asset asset);

        /// <summary>
        /// Delete Asset
        /// </summary>
        /// <param name="asset"></param>
        void Delete(Asset asset);
    }
}
