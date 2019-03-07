namespace PurchaseRequisition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "User.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        Zip = c.String(nullable: false, maxLength: 10),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "User.Campuses",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CampusName = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        AddressId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "User.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        RoomCode = c.String(nullable: false),
                        RoomName = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CampusId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Campuses", t => t.CampusId, cascadeDelete: true)
                .Index(t => t.CampusId);
            
            CreateTable(
                "User.Employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Active = c.Boolean(nullable: false),
                        DepartmentId = c.Int(),
                        RoomId = c.Int(),
                        UserName = c.String(),
                        NormalizedUserName = c.String(),
                        Email = c.String(),
                        NormalizedEmail = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        ConcurrencyStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(precision: 7),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User.Departments", t => t.DepartmentId)
                .ForeignKey("User.Rooms", t => t.RoomId)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "User.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        DepartmentName = c.String(),
                        Active = c.Boolean(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Divisions", t => t.DivisionId, cascadeDelete: true)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "User.Divisions",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        DivisionName = c.String(),
                        Active = c.Boolean(nullable: false),
                        SupervisorId = c.String(maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Employees", t => t.SupervisorId)
                .Index(t => t.SupervisorId);
            
            CreateTable(
                "User.EmployeesBudgetCodes",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        EmployeeId = c.String(maxLength: 128),
                        Active = c.Boolean(nullable: false),
                        BudgetCodeId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.BudgetCodes", t => t.BudgetCodeId, cascadeDelete: true)
                .ForeignKey("User.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.BudgetCodeId);
            
            CreateTable(
                "User.BudgetCodes",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        DA = c.Int(nullable: false),
                        BudgetCodeName = c.String(nullable: false),
                        Type = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "User.BudgetAmounts",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        BudgetCodeId = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.BudgetCodes", t => t.BudgetCodeId, cascadeDelete: true)
                .Index(t => t.BudgetCodeId);
            
            CreateTable(
                "Order.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        DateMade = c.DateTime(nullable: false),
                        DateOrdered = c.DateTime(),
                        StateContract = c.Boolean(nullable: false),
                        BusinessJustification = c.String(),
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        StatusId = c.Int(nullable: false),
                        CategoryId = c.Int(),
                        BudgetCodeId = c.Int(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Order.Categories", t => t.CategoryId)
                .ForeignKey("User.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("Order.Statuses", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("User.BudgetCodes", t => t.BudgetCodeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.StatusId)
                .Index(t => t.CategoryId)
                .Index(t => t.BudgetCodeId);
            
            CreateTable(
                "Order.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CategoryName = c.String(maxLength: 75),
                        Active = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Order.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        QuantityRequested = c.Int(nullable: false),
                        EstimatedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstimatedTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Chosen = c.Boolean(nullable: false),
                        OrderId = c.Int(nullable: false),
                        VendorId = c.Int(),
                        ItemId = c.Int(nullable: false),
                        ReasonChosen = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Order.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("Order.Vendors", t => t.VendorId)
                .ForeignKey("Order.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.VendorId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "Order.Attachments",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                        Content = c.Binary(nullable: false),
                        ContentType = c.String(),
                        FileName = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Order.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "Order.Items",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ItemName = c.String(maxLength: 50),
                        Description = c.String(maxLength: 200),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Order.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        VendorName = c.String(maxLength: 20),
                        Phone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        Website = c.String(maxLength: 20),
                        AddressId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "Order.Statuses",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        StatusName = c.String(maxLength: 50),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Order.SupervisorApprovals",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ApprovalId = c.Int(nullable: false),
                        OrderId = c.Int(),
                        UserRoleId = c.String(nullable: false, maxLength: 128),
                        SupervisorId = c.String(nullable: false, maxLength: 128),
                        DeniedJustification = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Order.Approval", t => t.ApprovalId, cascadeDelete: true)
                .ForeignKey("User.Employees", t => t.SupervisorId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRoles", t => t.UserRoleId, cascadeDelete: true)
                .ForeignKey("Order.Orders", t => t.OrderId)
                .Index(t => t.ApprovalId)
                .Index(t => t.OrderId)
                .Index(t => t.UserRoleId)
                .Index(t => t.SupervisorId);
            
            CreateTable(
                "Order.Approval",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ApprovalName = c.String(maxLength: 20),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        NormalizedName = c.String(),
                        ConcurrencyStamp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Order.Vendors", "AddressId", "User.Addresses");
            DropForeignKey("User.Campuses", "AddressId", "User.Addresses");
            DropForeignKey("User.Rooms", "CampusId", "User.Campuses");
            DropForeignKey("User.Employees", "RoomId", "User.Rooms");
            DropForeignKey("User.Divisions", "SupervisorId", "User.Employees");
            DropForeignKey("User.EmployeesBudgetCodes", "EmployeeId", "User.Employees");
            DropForeignKey("Order.Orders", "BudgetCodeId", "User.BudgetCodes");
            DropForeignKey("Order.SupervisorApprovals", "OrderId", "Order.Orders");
            DropForeignKey("Order.SupervisorApprovals", "UserRoleId", "dbo.IdentityRoles");
            DropForeignKey("Order.SupervisorApprovals", "SupervisorId", "User.Employees");
            DropForeignKey("Order.SupervisorApprovals", "ApprovalId", "Order.Approval");
            DropForeignKey("Order.Orders", "StatusId", "Order.Statuses");
            DropForeignKey("Order.Requests", "OrderId", "Order.Orders");
            DropForeignKey("Order.Requests", "VendorId", "Order.Vendors");
            DropForeignKey("Order.Requests", "ItemId", "Order.Items");
            DropForeignKey("Order.Attachments", "RequestId", "Order.Requests");
            DropForeignKey("Order.Orders", "EmployeeId", "User.Employees");
            DropForeignKey("Order.Orders", "CategoryId", "Order.Categories");
            DropForeignKey("User.EmployeesBudgetCodes", "BudgetCodeId", "User.BudgetCodes");
            DropForeignKey("User.BudgetAmounts", "BudgetCodeId", "User.BudgetCodes");
            DropForeignKey("User.Employees", "DepartmentId", "User.Departments");
            DropForeignKey("User.Departments", "DivisionId", "User.Divisions");
            DropIndex("Order.SupervisorApprovals", new[] { "SupervisorId" });
            DropIndex("Order.SupervisorApprovals", new[] { "UserRoleId" });
            DropIndex("Order.SupervisorApprovals", new[] { "OrderId" });
            DropIndex("Order.SupervisorApprovals", new[] { "ApprovalId" });
            DropIndex("Order.Vendors", new[] { "AddressId" });
            DropIndex("Order.Attachments", new[] { "RequestId" });
            DropIndex("Order.Requests", new[] { "ItemId" });
            DropIndex("Order.Requests", new[] { "VendorId" });
            DropIndex("Order.Requests", new[] { "OrderId" });
            DropIndex("Order.Orders", new[] { "BudgetCodeId" });
            DropIndex("Order.Orders", new[] { "CategoryId" });
            DropIndex("Order.Orders", new[] { "StatusId" });
            DropIndex("Order.Orders", new[] { "EmployeeId" });
            DropIndex("User.BudgetAmounts", new[] { "BudgetCodeId" });
            DropIndex("User.EmployeesBudgetCodes", new[] { "BudgetCodeId" });
            DropIndex("User.EmployeesBudgetCodes", new[] { "EmployeeId" });
            DropIndex("User.Divisions", new[] { "SupervisorId" });
            DropIndex("User.Departments", new[] { "DivisionId" });
            DropIndex("User.Employees", new[] { "RoomId" });
            DropIndex("User.Employees", new[] { "DepartmentId" });
            DropIndex("User.Rooms", new[] { "CampusId" });
            DropIndex("User.Campuses", new[] { "AddressId" });
            DropTable("dbo.IdentityRoles");
            DropTable("Order.Approval");
            DropTable("Order.SupervisorApprovals");
            DropTable("Order.Statuses");
            DropTable("Order.Vendors");
            DropTable("Order.Items");
            DropTable("Order.Attachments");
            DropTable("Order.Requests");
            DropTable("Order.Categories");
            DropTable("Order.Orders");
            DropTable("User.BudgetAmounts");
            DropTable("User.BudgetCodes");
            DropTable("User.EmployeesBudgetCodes");
            DropTable("User.Divisions");
            DropTable("User.Departments");
            DropTable("User.Employees");
            DropTable("User.Rooms");
            DropTable("User.Campuses");
            DropTable("User.Addresses");
        }
    }
}
