namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mappingInUserTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", new[] { "facility_Id" });
            DropColumn("dbo.User", "FacilityId");
            RenameColumn(table: "dbo.User", name: "facility_Id", newName: "FacilityId");
            AlterColumn("dbo.User", "FacilityId", c => c.Int());
            CreateIndex("dbo.User", "FacilityId");
            DropColumn("dbo.User", "FacilityName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "FacilityName", c => c.String());
            DropIndex("dbo.User", new[] { "FacilityId" });
            AlterColumn("dbo.User", "FacilityId", c => c.String());
            RenameColumn(table: "dbo.User", name: "FacilityId", newName: "facility_Id");
            AddColumn("dbo.User", "FacilityId", c => c.String());
            CreateIndex("dbo.User", "facility_Id");
        }
    }
}
