using PurchaseRequisition.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.ViewModels
{
    public class SupervisorApprovalWithApprovalViewModels : EntityBase
    {

        public string ApprovalName { get; set; }

        public string SupervisorName { get; set; }

        public string DeniedJustification { get; set; }
    }
}