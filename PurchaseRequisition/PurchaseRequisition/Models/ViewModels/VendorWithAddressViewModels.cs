using PurchaseRequisition.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.ViewModels
{
    public class VendorWithAddressViewModels : EntityBase
    {
        [Display(Name = "Vendor")]
        public string VendorName { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Website { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string ZIP { get; set; }
    }
}