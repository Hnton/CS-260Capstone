using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseRequisition.Models.Entities.Base;

namespace PurchaseRequisition.Models.Entities
{
    [Table("Approval", Schema = "Order")]
    public class Approval : EntityBase
    {
        [DataType(DataType.Text), MaxLength(20)]
        public string ApprovalName { get; set; }

        [InverseProperty(nameof(SupervisorApproval.Approval))]
        public List<SupervisorApproval> SupervisorApprovals { get; set; } = new List<SupervisorApproval>();
    }
}