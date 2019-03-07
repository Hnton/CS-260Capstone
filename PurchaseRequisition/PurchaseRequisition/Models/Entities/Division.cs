using PurchaseRequisition.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Not in use now, save just in case
 * Base recursive relationship off of ->https://stackoverflow.com/questions/27720369/one-to-many-recursive-relationship-with-code-first
 * 
 **/
namespace PurchaseRequisition.Models.Entities
{
    [Table("Divisions", Schema = "User")]
    public class Division : EntityBase
    {
        [DataType(DataType.Text)]
        public string DivisionName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        [InverseProperty(nameof(Department.Division))]
        public List<Department> Departments { get; set; } = new List<Department>();

        public string SupervisorId { get; set; }

        [ForeignKey("SupervisorId")]
        public Employee Supervisor { get; set; }
    }
}
