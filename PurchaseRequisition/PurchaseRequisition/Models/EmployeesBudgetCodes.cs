using PurchaseRequisition.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("EmployeesBudgetCodes", Schema = "User")]
    public class EmployeesBudgetCodes : EntityBase
    {
        [ForeignKey(nameof(EmployeeID))]
        public Employee Employee { get; set; }

        public string EmployeeID { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [ForeignKey(nameof(BudgetCodeID))]
        public BudgetCode BudgetCode { get; set; }

        public int BudgetCodeID { get; set; }
    }
}
