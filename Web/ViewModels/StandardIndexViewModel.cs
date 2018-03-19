using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Domains;

namespace Web.ViewModels
{
    public class StandardIndexViewModel
    {
        public IEnumerable<FacilityViewModel> Facilities { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<AssetViewModel> Assets { get; set; }

        public StandardIndexViewModel(IEnumerable<Facility> facility)
        {
            Facilities = facility.Select(x => new FacilityViewModel(x));
        }

        public StandardIndexViewModel(IEnumerable<User> userList)
        {
            Users = userList.Select(user => new UserViewModel
            {
                EmailId = user.EmailId,
                Id = user.Id,
                IsActive = user.IsActive,
                Password = user.PasswordHash,
                FacilityId = user.FacilityId
             
            });
        public StandardIndexViewModel(IEnumerable<User> user)
        {
            Users = user.Select(x => new UserViewModel(x));
        }

        public StandardIndexViewModel(IEnumerable<Asset> asset)
        {
            Assets = asset.Select(x => new AssetViewModel(x));
        }
    }

}