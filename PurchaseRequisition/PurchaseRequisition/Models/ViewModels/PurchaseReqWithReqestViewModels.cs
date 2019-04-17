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
        public string EmployeeFullName { get; set; }


        [Display(Name = "Supervisor")]
        public string SupervisorFullName { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Budget")]
        public string BudgetCodeName { get; set; }

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