namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uppdateforeginKeyRelatioon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facility", "User_Id", c => c.Int());
            CreateIndex("dbo.Facility", "User_Id");
            AddForeignKey("dbo.Facility", "User_Id", "dbo.User", "Id");
            DropColumn("dbo.User", "FacilityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "FacilityId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Facility", "User_Id", "dbo.User");
            DropIndex("dbo.Facility", new[] { "User_Id" });
            DropColumn("dbo.Facility", "User_Id");
        }
    }
}
