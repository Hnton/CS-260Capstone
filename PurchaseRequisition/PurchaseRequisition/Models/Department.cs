using PurchaseRequisition.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Departments", Schema = "User")]
    public class Department : EntityBase
    {
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        [ForeignKey(nameof(DivisionID))]
        public Division Division { get; set; }

        public int DivisionID { get; set; }

        [InverseProperty(nameof(Employee.Department))]
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}