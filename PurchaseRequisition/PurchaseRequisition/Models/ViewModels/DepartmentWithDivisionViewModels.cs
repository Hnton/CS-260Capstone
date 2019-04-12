using PurchaseRequisition.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.ViewModels
{
    public class DepartmentWithDivisionViewModels : EntityBase
    {
        [DataType(DataType.Text)]
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [Display(Name = "Division")]
        public string DivisionName { get; set; }
    }
}