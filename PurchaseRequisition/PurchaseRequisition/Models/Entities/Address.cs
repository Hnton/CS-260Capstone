using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseRequisition.Models.Entities.Base;

namespace PurchaseRequisition.Models.Entities
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

        [MaxLength(10)]
        [Required]
        public string Zip { get; set; }

        [InverseProperty(nameof(Campus.Address))]
        public List<Campus> Campuses { get; set; } = new List<Campus>();

        [InverseProperty(nameof(Vendor.Address))]
        public List<Vendor> Vendors { get; set; } = new List<Vendor>();
    }
}