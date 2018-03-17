namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittinmestamp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Asset", "CreatedTimeStamp", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Asset", "LastModifiedTimeStamp", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asset", "LastModifiedTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Asset", "CreatedTimeStamp", c => c.DateTime(nullable: false));
        }
    }
}