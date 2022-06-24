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

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }

        public int LabId { get; set; }
        [ForeignKey("LabId")]
        public virtual Lab Lab { get; set; }

        public int TypeEquipmentId { get; set; }
        [ForeignKey("TypeEquipmentId")]
        public virtual TypeEquipment TypeEquipment { get; set; }

    }
}