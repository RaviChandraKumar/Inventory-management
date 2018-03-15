namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mar135 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "UserName", c => c.String());
        }
    }
}
