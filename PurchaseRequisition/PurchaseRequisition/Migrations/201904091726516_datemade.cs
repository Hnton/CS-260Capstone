namespace PurchaseRequisition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datemade : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Order.Orders", "DateMade", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Order.Orders", "DateMade", c => c.DateTime(nullable: false));
        }
    }
}
