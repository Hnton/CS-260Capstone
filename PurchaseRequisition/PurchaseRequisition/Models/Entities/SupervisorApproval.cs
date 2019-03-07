using Microsoft.AspNetCore.Identity;
using PurchaseRequisition.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models.Entities
{
    [Table("SupervisorApprovals", Schema = "Order")]
    public class SupervisorApproval : EntityBase
    {
        public int ApprovalId { get; set; }

        [ForeignKey("ApprovalId")]
        public Approval Approval { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        public string UserRoleId { get; set; }

        [ForeignKey("UserRoleId")]
        public IdentityRole IdentityRole { get; set; }

        [Required]
        public string SupervisorId { get; set; }

        [ForeignKey("SupervisorId")]
        public Employee Employee { get; set; }

        [DataType(DataType.MultilineText)]
        public string DeniedJustification { get; set; }


    }
}
