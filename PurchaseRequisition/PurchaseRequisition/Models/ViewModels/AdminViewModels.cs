using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.ViewModels
{
    public class AdminViewModels
    {

        public class UserEdit
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [DataType(DataType.Text)]
            public string FirstName { get; set; }

            [DataType(DataType.Text)]
            public string LastName { get; set; }

            [DefaultValue(true)]
            public bool Active { get; set; }

            [ForeignKey(nameof(DepartmentID))]
            public Department Department { get; set; }

            public int? DepartmentID { get; set; }

            [ForeignKey(nameof(RoomID))]
            public Room Room { get; set; }

            public int? RoomID { get; set; }

        }
    }
}