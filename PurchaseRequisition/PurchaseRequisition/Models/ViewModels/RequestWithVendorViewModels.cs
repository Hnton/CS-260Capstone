using PurchaseRequisition.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.ViewModels
{
    public class RequestWithVendorViewModels : EntityBase
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

        public int orderID { get; set; }

        public List<Attachment> Attachments { get; set; } = new List<Attachment>();

        [DataType(DataType.Text), MaxLength(50)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        public int ItemID { get; set; }


        [DataType(DataType.Text), MaxLength(200)]
        public string Description { get; set; }

        [Display(Name = "Reason Chosen")]
        public string ReasonChosen { get; set; }

        [Display(Name = "Vendor")]
        public string VendorName { get; set; }

        public int VendorID { get; set; }

    }
}