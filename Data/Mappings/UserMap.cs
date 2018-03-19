using System.Data.Entity.ModelConfiguration;
using Core.Domains;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mappings
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Table 
            ToTable("User", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.EmailId)
                    .IsRequired()
                    .HasMaxLength(100);

            HasOptional(x => x.Facility)
                .WithMany()
                .HasForeignKey(x => x.FacilityId)
                .WillCascadeOnDelete(false);
            /* Property(c => c.PasswordHash)
                     .IsRequired();

              Property(c => c.PasswordSalt)
                      .IsRequired();*/
        }
    }
}
