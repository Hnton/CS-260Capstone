namespace PurchaseRequisition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "User.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        ZIP = c.String(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "User.Campuses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CampusName = c.String(nullable: false),
                        AddressID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
            CreateTable(
                "User.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoomCode = c.String(nullable: false),
                        RoomName = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CampusID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Campuses", t => t.CampusID, cascadeDelete: true)
                .Index(t => t.CampusID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "User.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Active = c.Boolean(nullable: false),
                        DivisionID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Divisions", t => t.DivisionID, cascadeDelete: true)
                .Index(t => t.DivisionID);
            
            CreateTable(
                "User.Divisions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DivisionName = c.String(),
                        Active = c.Boolean(nullable: false),
                        SupervisorID = c.String(maxLength: 128),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Employees", t => t.SupervisorID)
                .Index(t => t.SupervisorID);
            
            CreateTable(
                "User.EmployeesBudgetCodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.String(maxLength: 128),
                        Active = c.Boolean(nullable: false),
                        BudgetCodeID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.BudgetCodes", t => t.BudgetCodeID, cascadeDelete: true)
                .ForeignKey("User.Employees", t => t.EmployeeID)
                .Index(t => t.EmployeeID)
                .Index(t => t.BudgetCodeID);
            
            CreateTable(
                "User.BudgetCodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DA_CODE = c.Int(nullable: false),
                        BudgetCodeName = c.String(nullable: false),
                        Type = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "User.BudgetAmounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetCodeID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.BudgetCodes", t => t.BudgetCodeID, cascadeDelete: true)
                .Index(t => t.BudgetCodeID);
            
            CreateTable(
                "Order.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateMade = c.DateTime(nullable: false),
                        DateOrdered = c.DateTime(),
                        StateContract = c.Boolean(nullable: false),
                        BusinessJustification = c.String(),
                        EmployeeID = c.String(nullable: false, maxLength: 128),
                        StatusID = c.Int(nullable: false),
                        CategoryID = c.Int(),
                        BudgetCodeID = c.Int(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Order.Categories", t => t.CategoryID)
                .ForeignKey("User.Employees", t => t.EmployeeID)
                .ForeignKey("Order.Statuses", t => t.StatusID, cascadeDelete: true)
                .ForeignKey("User.BudgetCodes", t => t.BudgetCodeID)
                .Index(t => t.EmployeeID)
                .Index(t => t.StatusID)
                .Index(t => t.CategoryID)
                .Index(t => t.BudgetCodeID);
            
            CreateTable(
                "Order.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 256),
                        Active = c.Boolean(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Order.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuantityRequested = c.Int(nullable: false),
                        EstimatedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstimatedTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Chosen = c.Boolean(nullable: false),
                        OrderID = c.Int(nullable: false),
                        VendorID = c.Int(),
                        ItemID = c.Int(nullable: false),
                        ReasonChosen = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Order.Items", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("Order.Vendors", t => t.VendorID)
                .ForeignKey("Order.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.VendorID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "Order.Attachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestID = c.Int(nullable: false),
                        FileName = c.String(),
                        Content = c.Binary(nullable: false),
                        ContentType = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Order.Requests", t => t.RequestID, cascadeDelete: true)
                .Index(t => t.RequestID);
            
            CreateTable(
                "Order.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(maxLength: 50),
                        Description = c.String(maxLength: 256),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Order.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VendorName = c.String(maxLength: 50),
                        Phone = c.String(),
                        Fax = c.String(maxLength: 10),
                        Website = c.String(maxLength: 50),
                        AddressID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("User.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
            CreateTable(
                "Order.Statuses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(maxLength: 256),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Order.SupervisorApprovals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApprovalID = c.Int(nullable: false),
                        OrderID = c.Int(),
                        UserRoleID = c.String(nullable: false, maxLength: 128),
                        SupervisorID = c.String(nullable: false, maxLength: 128),
                        DeniedJustification = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Order.Approval", t => t.ApprovalID, cascadeDelete: true)
                .ForeignKey("User.Employees", t => t.SupervisorID)
                .ForeignKey("dbo.AspNetRoles", t => t.UserRoleID, cascadeDelete: true)
                .ForeignKey("Order.Orders", t => t.OrderID)
                .Index(t => t.ApprovalID)
                .Index(t => t.OrderID)
                .Index(t => t.UserRoleID)
                .Index(t => t.SupervisorID);
            
            CreateTable(
                "Order.Approval",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApprovalName = c.String(maxLength: 20),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "User.Employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Active = c.Boolean(nullable: false),
                        DepartmentID = c.Int(),
                        RoomID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("User.Departments", t => t.DepartmentID)
                .ForeignKey("User.Rooms", t => t.RoomID)
                .Index(t => t.Id)
                .Index(t => t.DepartmentID)
                .Index(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("User.Employees", "RoomID", "User.Rooms");
            DropForeignKey("User.Employees", "DepartmentID", "User.Departments");
            DropForeignKey("User.Employees", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("Order.Vendors", "AddressID", "User.Addresses");
            DropForeignKey("User.Campuses", "AddressID", "User.Addresses");
            DropForeignKey("User.Rooms", "CampusID", "User.Campuses");
            DropForeignKey("User.EmployeesBudgetCodes", "EmployeeID", "User.Employees");
            DropForeignKey("Order.Orders", "BudgetCodeID", "User.BudgetCodes");
            DropForeignKey("Order.SupervisorApprovals", "OrderID", "Order.Orders");
            DropForeignKey("Order.SupervisorApprovals", "UserRoleID", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("Order.SupervisorApprovals", "SupervisorID", "User.Employees");
            DropForeignKey("Order.SupervisorApprovals", "ApprovalID", "Order.Approval");
            DropForeignKey("Order.Orders", "StatusID", "Order.Statuses");
            DropForeignKey("Order.Requests", "OrderID", "Order.Orders");
            DropForeignKey("Order.Requests", "VendorID", "Order.Vendors");
            DropForeignKey("Order.Requests", "ItemID", "Order.Items");
            DropForeignKey("Order.Attachments", "RequestID", "Order.Requests");
            DropForeignKey("Order.Orders", "EmployeeID", "User.Employees");
            DropForeignKey("Order.Orders", "CategoryID", "Order.Categories");
            DropForeignKey("User.EmployeesBudgetCodes", "BudgetCodeID", "User.BudgetCodes");
            DropForeignKey("User.BudgetAmounts", "BudgetCodeID", "User.BudgetCodes");
            DropForeignKey("User.Divisions", "SupervisorID", "User.Employees");
            DropForeignKey("User.Departments", "DivisionID", "User.Divisions");
            DropIndex("User.Employees", new[] { "RoomID" });
            DropIndex("User.Employees", new[] { "DepartmentID" });
            DropIndex("User.Employees", new[] { "Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("Order.SupervisorApprovals", new[] { "SupervisorID" });
            DropIndex("Order.SupervisorApprovals", new[] { "UserRoleID" });
            DropIndex("Order.SupervisorApprovals", new[] { "OrderID" });
            DropIndex("Order.SupervisorApprovals", new[] { "ApprovalID" });
            DropIndex("Order.Vendors", new[] { "AddressID" });
            DropIndex("Order.Attachments", new[] { "RequestID" });
            DropIndex("Order.Requests", new[] { "ItemID" });
            DropIndex("Order.Requests", new[] { "VendorID" });
            DropIndex("Order.Requests", new[] { "OrderID" });
            DropIndex("Order.Orders", new[] { "BudgetCodeID" });
            DropIndex("Order.Orders", new[] { "CategoryID" });
            DropIndex("Order.Orders", new[] { "StatusID" });
            DropIndex("Order.Orders", new[] { "EmployeeID" });
            DropIndex("User.BudgetAmounts", new[] { "BudgetCodeID" });
            DropIndex("User.EmployeesBudgetCodes", new[] { "BudgetCodeID" });
            DropIndex("User.EmployeesBudgetCodes", new[] { "EmployeeID" });
            DropIndex("User.Divisions", new[] { "SupervisorID" });
            DropIndex("User.Departments", new[] { "DivisionID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("User.Rooms", new[] { "CampusID" });
            DropIndex("User.Campuses", new[] { "AddressID" });
            DropTable("User.Employees");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
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
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("User.Rooms");
            DropTable("User.Campuses");
            DropTable("User.Addresses");
        }
    }
}
