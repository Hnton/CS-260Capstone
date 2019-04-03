using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace PurchaseRequisition.Models
{
    [Table("Employees", Schema = "User")]
    public class Employee : IdentityUser
    {
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
        
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        public Department Department { get; set; }

        public int? DepartmentID { get; set; }

        [InverseProperty(nameof(EmployeesBudgetCodes.Employee))]
        public List<EmployeesBudgetCodes> EmployeesBudgetCode { get; set; } = new List<EmployeesBudgetCodes>();

        [InverseProperty(nameof(Division.Supervisor))]
        public List<Division> Divisions { get; set; } = new List<Division>();

        [ForeignKey(nameof(RoomID))]
        public Room Room { get; set; }

        public int? RoomID { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Employee> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
}