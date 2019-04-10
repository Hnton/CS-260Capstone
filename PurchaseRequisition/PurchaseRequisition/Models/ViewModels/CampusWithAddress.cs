using PurchaseRequisition.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseRequisition.Models.ViewModels
{
    public class CampusWithAddress : EntityBase
    {
        [Required]
        public string CampusName { get; set; }

        public int AddressID { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string ZIP { get; set; }
    }
}