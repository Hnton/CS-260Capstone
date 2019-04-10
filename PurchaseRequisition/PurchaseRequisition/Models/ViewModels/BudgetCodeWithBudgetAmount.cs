using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PurchaseRequisition.Models.Base;

namespace PurchaseRequisition.Models.ViewModels
{
    public class BudgetCodeWithBudgetAmount : EntityBase
    {
        [Required]
        public int DA_CODE { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string BudgetCodeName { get; set; }

        [Required]
        public bool Type { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        public int BudgetAmountId;
    }
}