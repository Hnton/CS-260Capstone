using PurchaseRequisition.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models.Entities
{
    [Table("Statuses", Schema = "Order")]
    public class Status : EntityBase
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(Order.Status))]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}