using PurchaseRequisition.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Divisions", Schema = "User")]
    public class Division : EntityBase
    {
        [DataType(DataType.Text)]
        public string DivisionName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [ForeignKey(nameof(SupervisorID))]
        public Employee Supervisor { get; set; }

        public string SupervisorID { get; set; }

        [InverseProperty(nameof(Department.Division))]
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}