using PurchaseRequisition.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Items", Schema = "Order")]
    public class Item : EntityBase
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string ItemName { get; set; }

        [DataType(DataType.Text), MaxLength(256)]
        public string Description { get; set; }

        [InverseProperty(nameof(Request.Item))]
        public List<Request> Requests { get; set; } = new List<Request>();
    }
}