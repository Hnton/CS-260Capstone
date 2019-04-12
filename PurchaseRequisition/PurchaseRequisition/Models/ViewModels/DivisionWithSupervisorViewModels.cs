using PurchaseRequisition.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.ViewModels
{
    public class DivisionWithSupervisorViewModels : EntityBase
    {
        [DataType(DataType.Text)]
        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [Display(Name = "Supervisor")]
        public string SupervisorName { get; set; }
    }
}