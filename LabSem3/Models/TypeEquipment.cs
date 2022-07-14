using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class TypeEquipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int EquipmentId { get; set; }
        [ForeignKey("ComplaintId")]
        public virtual List<Equipment> Equipments { get; set; }
    }
}