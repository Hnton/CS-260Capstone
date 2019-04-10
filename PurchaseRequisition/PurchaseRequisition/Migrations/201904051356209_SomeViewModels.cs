namespace PurchaseRequisition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeViewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CampusWithAddresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CampusName = c.String(nullable: false),
                        AddressID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        ZIP = c.String(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CampusWithAddresses");
        }
    }
}
