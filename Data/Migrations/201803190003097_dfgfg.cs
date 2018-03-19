namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfgfg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FacilityName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "FacilityName");
        }
    }
}
