using PurchaseRequisition.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.ViewModels
{
    public class PurchaseReqWithReqestViewModels : EntityBase
    {
        [Display(Name = "Requester")]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeID { get; set; }


        [Display(Name = "Supervisor")]
        public string SupervisorName { get; set; }

        [Required]
        public string SupervisorID { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Display(Name = "Budget")]
        public string BudgetCodeName { get; set; }

        [Required]
        public int BudgetCodeID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime DateMade { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ordered")]
        public DateTime? DateOrdered { get; set; }

        [DefaultValue(false)]
        [Display(Name = "State Contract")]
        public bool StateContract { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Business Justification")]
        public string BusinessJustification { get; set; }

        public List<RequestWithVendorViewModels> RequestsWithVendor { get; set; } = new List<RequestWithVendorViewModels>();

        ////I Don't think this is necessary
        //public List<SupervisorApprovalWithApprovalViewModels> SupervisorApprovalWithApprovals { get; set; } = new List<SupervisorApprovalWithApprovalViewModels>();

    }
}