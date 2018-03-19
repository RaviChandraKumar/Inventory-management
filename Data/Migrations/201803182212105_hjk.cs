namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hjk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "FacilityId", "dbo.Facility");
            DropIndex("dbo.User", new[] { "FacilityId" });
            AddColumn("dbo.User", "facility_Id", c => c.Int());
            AlterColumn("dbo.User", "FacilityId", c => c.String());
            CreateIndex("dbo.User", "facility_Id");
            AddForeignKey("dbo.User", "facility_Id", "dbo.Facility", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "facility_Id", "dbo.Facility");
            DropIndex("dbo.User", new[] { "facility_Id" });
            AlterColumn("dbo.User", "FacilityId", c => c.Int());
            DropColumn("dbo.User", "facility_Id");
            CreateIndex("dbo.User", "FacilityId");
            AddForeignKey("dbo.User", "FacilityId", "dbo.Facility", "Id");
        }
    }
}
