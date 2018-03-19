namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignRelBwUserAndFacility : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facility", "UserId", c => c.Int());
            CreateIndex("dbo.Facility", "UserId");
            AddForeignKey("dbo.Facility", "UserId", "dbo.User", "Id");
            DropColumn("dbo.User", "FacilityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "FacilityId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Facility", "UserId", "dbo.User");
            DropIndex("dbo.Facility", new[] { "UserId" });
            DropColumn("dbo.Facility", "UserId");
        }
    }
}
