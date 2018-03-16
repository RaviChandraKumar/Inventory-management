namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03152018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asset",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        InitCount = c.Int(nullable: false),
                        UsedCount = c.Int(nullable: false),
                        UnusedCount = c.Int(nullable: false),
                        CreatedTimeStamp = c.DateTime(nullable: false),
                        LastModifiedTimeStamp = c.DateTime(nullable: false),
                        CreatedUser = c.String(),
                        LastModifiedUser = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Asset");
        }
    }
}
