namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FacilityId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "FacilityId");
        }
    }
}
