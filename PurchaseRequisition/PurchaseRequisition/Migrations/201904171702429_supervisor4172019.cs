namespace PurchaseRequisition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supervisor4172019 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Order.SupervisorApprovals", "OrderID", "Order.Orders");
            DropForeignKey("Order.SupervisorApprovals", "UserRoleID", "dbo.AspNetRoles");
            DropIndex("Order.SupervisorApprovals", new[] { "OrderID" });
            DropIndex("Order.SupervisorApprovals", new[] { "UserRoleID" });
            DropIndex("Order.SupervisorApprovals", new[] { "SupervisorID" });
            AlterColumn("Order.SupervisorApprovals", "OrderID", c => c.Int(nullable: false));
            AlterColumn("Order.SupervisorApprovals", "UserRoleID", c => c.String(maxLength: 128));
            AlterColumn("Order.SupervisorApprovals", "SupervisorID", c => c.String(maxLength: 128));
            CreateIndex("Order.SupervisorApprovals", "OrderID");
            CreateIndex("Order.SupervisorApprovals", "UserRoleID");
            CreateIndex("Order.SupervisorApprovals", "SupervisorID");
            AddForeignKey("Order.SupervisorApprovals", "OrderID", "Order.Orders", "ID", cascadeDelete: true);
            AddForeignKey("Order.SupervisorApprovals", "UserRoleID", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Order.SupervisorApprovals", "UserRoleID", "dbo.AspNetRoles");
            DropForeignKey("Order.SupervisorApprovals", "OrderID", "Order.Orders");
            DropIndex("Order.SupervisorApprovals", new[] { "SupervisorID" });
            DropIndex("Order.SupervisorApprovals", new[] { "UserRoleID" });
            DropIndex("Order.SupervisorApprovals", new[] { "OrderID" });
            AlterColumn("Order.SupervisorApprovals", "SupervisorID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("Order.SupervisorApprovals", "UserRoleID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("Order.SupervisorApprovals", "OrderID", c => c.Int());
            CreateIndex("Order.SupervisorApprovals", "SupervisorID");
            CreateIndex("Order.SupervisorApprovals", "UserRoleID");
            CreateIndex("Order.SupervisorApprovals", "OrderID");
            AddForeignKey("Order.SupervisorApprovals", "UserRoleID", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("Order.SupervisorApprovals", "OrderID", "Order.Orders", "ID");
        }
    }
}
