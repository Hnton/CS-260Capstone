using PurchaseRequisition.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Attachments", Schema = "Order")]
    public class Attachment : EntityBase
    {
        [ForeignKey(nameof(RequestID))]
        public Request Request { get; set; }

        public int RequestID { get; set; }

        public string FileName { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public string ContentType { get; set; }
    }
}