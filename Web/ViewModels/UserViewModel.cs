using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domains;

namespace Web.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int Id { get; set; }


        [MaxLength(20)]
        [Display(Name = "Email Id")]
        public string UserName { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [MaxLength(20)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(200)]
        [Display(Name = "Role")]
        public string Role { get; set; }

        public string LastModifiedUser { get; set; }

        public IEnumerable<Facility> ListOfAllFacilities { get; set; }

        public IEnumerable<Facility> ListOfFacilitiesAssigned { get; set; }

        public List<int> ListOfFacilityIds { get; set; }

        public UserViewModel(User user)
        {
           Id = user.Id;
           UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role;
           IsActive = user.IsActive;
           Password = user.PasswordHash;
           ListOfFacilitiesAssigned = user.Facilities;
        }

        public UserViewModel()
        {

        }
    }
}
