namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mar133 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "UserName", c => c.String());
            AlterColumn("dbo.User", "EmailId", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "EmailId", c => c.String());
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
