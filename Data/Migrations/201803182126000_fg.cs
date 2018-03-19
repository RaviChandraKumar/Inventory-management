namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fg : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.User", "FacilityId");
            AddForeignKey("dbo.User", "FacilityId", "dbo.Facility", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "FacilityId", "dbo.Facility");
            DropIndex("dbo.User", new[] { "FacilityId" });
        }
    }
}
