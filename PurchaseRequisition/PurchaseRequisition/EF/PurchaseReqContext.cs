using PurchaseRequisition.Models.Entities;
using System.Data.Entity;

namespace PurchaseRequisition.EF
{
    public class PurchaseReqContext : DbContext
    {

        public PurchaseReqContext() :base("PurchaseReqContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Approval> Approval { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<SupervisorApproval> SupervisorApprovals { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BudgetCode> BudgetCodes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<EmployeesBudgetCodes> EmployeesBudgetCodes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<BudgetAmount> BudgetAmounts { get; set; }
        public DbSet<Room> Rooms { get; set; }

        
    }
}