using PurchaseRequisition.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseRequisition.Models.ViewModels
{
    public class EmployeeBudgetCode :EntityBase
    {
        [Display(Name = "Full Name")]
        public string FullName => FirstName + " " + LastName;

        public string LastName { get; private set; }
        public string FirstName { get; private set; }

        [Required]
        public string EmployeeID { get; set; }

        [Required]
        public int BudgetCodeID { get; set; }

        [Display(Name = "Budget Name")]
        public string BudgetCodeName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
    }
}