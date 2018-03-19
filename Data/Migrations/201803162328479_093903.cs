namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _093903 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facility", "User_Id", c => c.Int());
            CreateIndex("dbo.Facility", "User_Id");
            AddForeignKey("dbo.Facility", "User_Id", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facility", "User_Id", "dbo.User");
            DropIndex("dbo.Facility", new[] { "User_Id" });
            DropColumn("dbo.Facility", "User_Id");
        }
    }
}
