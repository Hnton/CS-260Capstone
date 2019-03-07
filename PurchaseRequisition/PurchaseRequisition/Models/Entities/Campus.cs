using PurchaseRequisition.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequisition.Models.Entities
{
    [Table("Campuses", Schema = "User")]
    public class Campus : EntityBase
    {
        [Required]
        public string CampusName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [InverseProperty(nameof(Room.Campus))]
        public List<Room> Rooms { get; set; }
    }
}
