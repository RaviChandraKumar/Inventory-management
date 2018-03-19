using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
   public  class Asset : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int InitCount { get; set; }
        public int UsedCount { get; set; }
        public int UnusedCount { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public DateTime LastModifiedTimeStamp { get; set; }
        public string CreatedUser { get; set; }
        public string LastModifiedUser { get; set; }
        public bool IsActive { get; set; }
    }
}
