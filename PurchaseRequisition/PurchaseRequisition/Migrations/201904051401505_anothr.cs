namespace PurchaseRequisition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anothr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CampusWithAddresses", "AddressID", "User.Addresses");
            DropIndex("dbo.CampusWithAddresses", new[] { "AddressID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.CampusWithAddresses", "AddressID");
            AddForeignKey("dbo.CampusWithAddresses", "AddressID", "User.Addresses", "ID", cascadeDelete: true);
        }
    }
}
