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

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int EquipmentId { get; set; }
        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }

    }
}