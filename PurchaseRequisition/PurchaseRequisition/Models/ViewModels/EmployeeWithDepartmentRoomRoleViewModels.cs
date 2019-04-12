using PurchaseRequisition.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.ViewModels
{
    public class EmployeeWithDepartmentRoomRoleViewModels : EntityBase
    {
        [DataType(DataType.Text)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        [Display(Name = "Room Nunber")]
        public string RoomCode { get; set; }


        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}