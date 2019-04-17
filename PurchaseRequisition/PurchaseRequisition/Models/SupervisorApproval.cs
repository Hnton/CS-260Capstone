using Microsoft.AspNet.Identity.EntityFramework;
using PurchaseRequisition.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("SupervisorApprovals", Schema = "Order")]
    public class SupervisorApproval : EntityBase
    {
        [ForeignKey(nameof(ApprovalID))]
        public Approval Approval { get; set; }

        public int ApprovalID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }

        public int OrderID { get; set; }

        [ForeignKey(nameof(UserRoleID))]
        public IdentityRole IdentityRole { get; set; }

        public string UserRoleID { get; set; }

        [ForeignKey(nameof(SupervisorID))]
        public Employee Employee { get; set; }

        public string SupervisorID { get; set; }

        [DataType(DataType.MultilineText)]
        public string DeniedJustification { get; set; }
    }
}