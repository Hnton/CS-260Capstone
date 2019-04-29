using PurchaseRequisition.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.ViewModels
{
    public class RoomWithCampusViewModels : EntityBase
    {
        [Required]
        [Display(Name = "Room Code")]
        public string RoomCode { get; set; }

        [Required]
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public string CampusName { get; set; }

        public int CampusID { get; set; }
    }
}