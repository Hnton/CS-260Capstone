using PurchaseRequisition.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseRequisition.Models.ViewModels
{
    public class BudgetCodeWithAmountViewModels : EntityBase
    {
        [Required]
        public int DA_CODE { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Budget Name")]
        public string BudgetCodeName { get; set; }

        [Required]
        [Display(Name = "Annual")]
        public bool Type { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
    }
}