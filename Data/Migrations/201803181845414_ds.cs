
namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facility", "User_Id", "dbo.User");
            DropIndex("dbo.Facility", new[] { "User_Id" });
            DropColumn("dbo.Facility", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facility", "User_Id", c => c.Int());
            CreateIndex("dbo.Facility", "User_Id");
            AddForeignKey("dbo.Facility", "User_Id", "dbo.User", "Id");
        }
    }
}
