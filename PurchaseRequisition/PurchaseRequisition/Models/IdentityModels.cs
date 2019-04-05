using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PurchaseRequisition.Models
{
    //// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //    public DateTime BirthDate { get; set; }

    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Approval> Approval { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<BudgetAmount> BudgetAmounts { get; set; }
        public DbSet<BudgetCode> BudgetCodes { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeesBudgetCodes> EmployeesBudgetCodes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<SupervisorApproval> SupervisorApprovals { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PurchaseRequisition.Models.ViewModels.CampusWithAddress> CampusWithAddresses { get; set; }
    }
}