using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class User : BaseEntity
    {
        public string EmailId { get; set; }
        public string Role { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public int? FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
    }
}
