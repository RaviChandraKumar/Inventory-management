namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kcdkl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FacilityId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "FacilityId");
        }
    }
}
