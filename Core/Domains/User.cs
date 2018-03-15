using System;
using System.Collections.Generic;
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
    }
}
