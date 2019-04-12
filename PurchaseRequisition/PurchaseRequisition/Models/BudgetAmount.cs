using PurchaseRequisition.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("BudgetAmounts", Schema = "User")]
    public class BudgetAmount : EntityBase
    {
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(BudgetCodeID))]
        public BudgetCode BudgetCode { get; set; }

        public int BudgetCodeID { get; set; }

        
    }
}