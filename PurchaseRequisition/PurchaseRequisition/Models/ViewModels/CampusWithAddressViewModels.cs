using PurchaseRequisition.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models.ViewModels
{
    public class CampusWithAddressViewModels : EntityBase
    {
        [Required]
        [Display(Name = "Campus Name")]
        public string CampusName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [MaxLength(10)]
        [Required]
        public string ZIP { get; set; }
    }
}