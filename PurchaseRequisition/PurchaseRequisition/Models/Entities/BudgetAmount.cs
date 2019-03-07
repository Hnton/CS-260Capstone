using PurchaseRequisition.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models.Entities
{
    [Table("BudgetAmounts", Schema = "User")]
    public class BudgetAmount : EntityBase
    {
        public int BudgetCodeId { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [ForeignKey("BudgetCodeId")]
        public BudgetCode BudgetCode { get; set; }
    }
}