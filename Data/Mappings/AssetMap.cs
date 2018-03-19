
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class AssetMap : EntityTypeConfiguration<Asset>
    {
        public AssetMap()
        {
            // Table 
            ToTable("Asset", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Description)
                .IsRequired();

            Property(c => c.InitCount)
                .IsRequired();

            Property(c => c.CreatedTimeStamp)
                .HasColumnType("datetime2");

            Property(c => c.LastModifiedTimeStamp)
                 .HasColumnType("datetime2");



        }
    }
}
