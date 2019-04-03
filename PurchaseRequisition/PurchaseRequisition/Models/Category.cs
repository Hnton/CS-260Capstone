using PurchaseRequisition.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Categories", Schema = "Order")]
    public class Category : EntityBase
    {
        [DataType(DataType.Text), MaxLength(256)]
        public string CategoryName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        [InverseProperty(nameof(Order.Category))]
        public List<Order> Orders { get; set; }
    }
}