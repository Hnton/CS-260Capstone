using PurchaseRequisition.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseRequisition.Models.ViewModels
{
    public class DivisionWithSupervisor : EntityBase
    {
        [DataType(DataType.Text)]
        public string DivisionName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public string SupervisorID { get; set; }

        [Display(Name = "Supervisor")]
        public string SupervisorName { get; set; }
    }
}