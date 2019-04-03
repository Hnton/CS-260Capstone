using System.Collections.Generic;
using PurchaseRequisition.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Addresses", Schema = "User")]
    public class Address : EntityBase
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string ZIP { get; set; }

        [InverseProperty(nameof(Campus.Address))]
        public List<Campus> Campuses { get; set; } = new List<Campus>();

        [InverseProperty(nameof(Vendor.Address))]
        public List<Vendor> Vendors { get; set; } = new List<Vendor>();
    }
}