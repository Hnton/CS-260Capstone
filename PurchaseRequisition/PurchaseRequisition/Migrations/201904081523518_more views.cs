namespace PurchaseRequisition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetCodeWithBudgetAmounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DA_CODE = c.Int(nullable: false),
                        BudgetCodeName = c.String(nullable: false),
                        Type = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BudgetCodeWithBudgetAmounts");
        }
    }
}
