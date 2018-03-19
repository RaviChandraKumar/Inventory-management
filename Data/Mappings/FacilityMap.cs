
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class FacilityMap : EntityTypeConfiguration<Facility>
    {
        public FacilityMap()
        {
            // Table 
            ToTable("Facility", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Landmark)
                .IsRequired();

            Property(c => c.Address)
                .IsRequired();

            Property(c => c.UserId)
                .IsOptional();

           HasOptional(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);


        }
    }
}
