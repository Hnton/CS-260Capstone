using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Models.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            TimeStamp = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; }
    }
}