using PurchaseRequisition.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models.Entities
{
    [Table("Orders", Schema = "Order")]
    public class Order : EntityBase
    {
        public Order()
        {
            DateMade = DateTime.Now;        
        }

        [DataType(DataType.Date)]
        public DateTime DateMade { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOrdered { get; set; }

        [DefaultValue(false)]
        public bool StateContract { get; set; }

        [DataType(DataType.MultilineText)]
        public string BusinessJustification { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        //In case no work
        [InverseProperty(nameof(SupervisorApproval.Order))]
        public List<SupervisorApproval> SupervisorApprovals { get; set; }

        [InverseProperty(nameof(Request.Order))]
        public List<Request> Requests { get; set; }

        public int? BudgetCodeId { get; set; }

        [ForeignKey("BudgetCodeId")]
        public BudgetCode BudgetCode { get; set; }


    }


}
