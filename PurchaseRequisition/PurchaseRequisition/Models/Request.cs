using PurchaseRequisition.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Requests", Schema = "Order")]
    public class Request : EntityBase
    {
        [Display(Name = "Quantity Requested")]
        public int QuantityRequested { get; set; }

        [Display(Name = "Estimated Cost")]
        [DataType(DataType.Currency)]
        public decimal EstimatedCost { get; set; }

        [Display(Name = "Estimated Total")]
        [DataType(DataType.Currency)]
        public decimal EstimatedTotal { get; set; }

        [Display(Name = "Paid Cost")]
        [DataType(DataType.Currency)]
        public decimal PaidCost { get; set; }

        [Display(Name = "Paid Total")]
        [DataType(DataType.Currency)]
        public decimal PaidTotal { get; set; }

        [DefaultValue(true)]
        public bool Chosen { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }

        public int OrderID { get; set; }

        [ForeignKey(nameof(VendorID))]
        public Vendor Vendor { get; set; }

        public int? VendorID { get; set; }

        [ForeignKey(nameof(ItemID))]
        public Item Item { get; set; }

        public int ItemID { get; set; }

        public string ReasonChosen { get; set; }

        [InverseProperty(nameof(Attachment.Request))]
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}