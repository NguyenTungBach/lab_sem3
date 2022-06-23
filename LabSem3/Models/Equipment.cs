using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Equipment Name")]
        [Required(ErrorMessage = "Name Equipment Require")]
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int LabId { get; set; }
        [ForeignKey("LabId")]
        public virtual Lab Lab { get; set; }

        public int TypeEquipmentId { get; set; }
        [ForeignKey("TypeEquipmentId")]
        public virtual TypeEquipment TypeEquipment { get; set; }

    }
}