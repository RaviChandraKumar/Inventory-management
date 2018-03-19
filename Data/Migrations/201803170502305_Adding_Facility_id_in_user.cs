namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_Facility_id_in_user : DbMigration
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
