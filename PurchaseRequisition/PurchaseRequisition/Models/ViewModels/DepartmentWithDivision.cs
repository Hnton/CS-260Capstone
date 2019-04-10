using PurchaseRequisition.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PurchaseRequisition.Models.ViewModels
{
    public class DepartmentWithDivision : EntityBase
    {
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        public int DivisionID { get; set; }

        [DataType(DataType.Text)]
        public string DivisionName { get; set; }
    }
}