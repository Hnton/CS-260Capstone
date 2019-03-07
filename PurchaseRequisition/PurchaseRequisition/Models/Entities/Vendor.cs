using PurchaseRequisition.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PurchaseRequisition.Models.Entities
{
    [Table("Vendors", Schema = "Order")]
    public class Vendor : EntityBase
    {

        [DataType(DataType.Text), MaxLength(20)]
        public string VendorName { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string Phone { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string Fax { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string Website { get; set; }

        [InverseProperty(nameof(Request.Vendor))]
        public List<Request> Requests { get; set; } = new List<Request>();

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }


    }
}
