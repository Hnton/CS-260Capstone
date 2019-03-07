using PurchaseRequisition.Models.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models.Entities
{
    [Table("EmployeesBudgetCodes", Schema = "User")]
    public class EmployeesBudgetCodes : EntityBase
    {
        public string EmployeeId { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int BudgetCodeId { get; set; }

        [ForeignKey("BudgetCodeId")]
        public BudgetCode BudgetCode { get; set; }
    }
}
