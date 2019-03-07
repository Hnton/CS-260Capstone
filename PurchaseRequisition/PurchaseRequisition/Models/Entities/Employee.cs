using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PurchaseRequisition.Models.Entities
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
        public bool Active { get; set; } = true;

        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [InverseProperty(nameof(EmployeesBudgetCodes.Employee))]
        public List<EmployeesBudgetCodes> EmployeesBudgetCode { get; set; } = new List<EmployeesBudgetCodes>();

        [InverseProperty(nameof(Division.Supervisor))]
        public List<Division> SupervisedDivision { get; set; } = new List<Division>();

        public int? RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }


    }
}
