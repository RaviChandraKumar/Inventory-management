namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mar132 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.User", "EmailId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "EmailId", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.User", "UserName");
        }
    }
}
