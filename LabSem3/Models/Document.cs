using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title Document Require")]
        public string Title { get; set; }
        [DataType(DataType.Text)]

        [Required(ErrorMessage = "Detail Document Require")]
        public string Detail { get; set; }
       
        public int Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }

        public int? TypeEquipmentId { get; set; }
        [ForeignKey("TypeEquipmentId")]
        public virtual TypeEquipment TypeEquipment { get; set; }

    }
}