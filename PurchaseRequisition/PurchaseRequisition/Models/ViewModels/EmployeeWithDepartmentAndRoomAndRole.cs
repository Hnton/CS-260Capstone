using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PurchaseRequisition.Models.Base;

namespace PurchaseRequisition.Models.ViewModels
{
    public class EmployeeWithDepartmentAndRoomAndRole : EntityBase
    {
        [DataType(DataType.Text)]
        [Display(Name = "First")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public int? DepartmentID { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        public int? RoomID { get; set; }

        [Display(Name = "Room")]
        public string RoomName { get; set; }

        [Required]
        public string RoleID { get; set; }

        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}