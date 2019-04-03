using PurchaseRequisition.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Vendors", Schema = "Order")]
    public class Vendor : EntityBase
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string VendorName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.Text), MaxLength(10)]
        public string Fax { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        public string Website { get; set; }

        [ForeignKey(nameof(AddressID))]
        public Address Address { get; set; }

        public int AddressID { get; set; }

        [InverseProperty(nameof(Request.Vendor))]
        public List<Request> Requests { get; set; } = new List<Request>();
    }
}