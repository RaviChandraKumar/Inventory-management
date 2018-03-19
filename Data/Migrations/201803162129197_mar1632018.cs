namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mar1632018 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserAndFacilityMap");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAndFacilityMap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FacilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
