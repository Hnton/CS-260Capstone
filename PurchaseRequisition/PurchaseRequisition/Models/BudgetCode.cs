using PurchaseRequisition.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("BudgetCodes", Schema = "User")]
    public class BudgetCode : EntityBase
    {
        [Required]
        public int DA_CODE { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string BudgetCodeName { get; set; }

        [Required]
        [Display(Name = "Annual")]
        public bool Type { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [InverseProperty(nameof(BudgetAmount.BudgetCode))]
        public List<BudgetAmount> BudgetAmounts { get; set; } = new List<BudgetAmount>();

        [InverseProperty(nameof(EmployeesBudgetCodes.BudgetCode))]
        public List<EmployeesBudgetCodes> EmployeesBudgetCode { get; set; } = new List<EmployeesBudgetCodes>();

        [InverseProperty(nameof(Order.BudgetCode))]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
