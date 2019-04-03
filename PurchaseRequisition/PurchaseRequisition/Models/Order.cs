using PurchaseRequisition.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Orders", Schema = "Order")]
    public class Order : EntityBase
    {
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateMade { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOrdered { get; set; }

        [DefaultValue(false)]
        public bool StateContract { get; set; }

        [DataType(DataType.MultilineText)]
        public string BusinessJustification { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        public Employee Employee { get; set; }

        [Required]
        public string EmployeeID { get; set; }

        [ForeignKey(nameof(StatusID))]
        public Status Status { get; set; }

        public int StatusID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public Category Category { get; set; }

        public int? CategoryID { get; set; }
     
        [ForeignKey(nameof(BudgetCodeID))]
        public BudgetCode BudgetCode { get; set; }

        public int? BudgetCodeID { get; set; }

        [InverseProperty(nameof(SupervisorApproval.Order))]
        public List<SupervisorApproval> SupervisorApprovals { get; set; }

        [InverseProperty(nameof(Request.Order))]
        public List<Request> Requests { get; set; }
    }


}