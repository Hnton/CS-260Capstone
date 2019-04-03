using PurchaseRequisition.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models
{
    [Table("Campuses", Schema = "User")]
    public class Campus : EntityBase
    {
        [Required]
        public string CampusName { get; set; }

        [ForeignKey(nameof(AddressID))]
        public Address Address { get; set; }

        public int AddressID { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        [InverseProperty(nameof(Room.Campus))]
        public List<Room> Rooms { get; set; }
    }
}