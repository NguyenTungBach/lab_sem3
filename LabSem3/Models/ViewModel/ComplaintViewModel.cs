using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using JetBrains.Annotations;

namespace LabSem3.Models.ViewModel
{
    public class ComplaintViewModel
    {
        [Required]
        [DisplayName("Type of complaint")]
        public int TypeComplaintId { get; set; }
        [Required(ErrorMessage = "Title Require")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("ID Of Equipment")]
        [Required(ErrorMessage = "EquipmentId Require")]
        [CanBeNull]
        public string EquipmentId { get; set; }

        [Required(ErrorMessage = "Detail Require")]
        [DisplayName("Detail about your problem")]
        [DataType(DataType.Text)]
        public string Detail { get; set; }

        [DisplayName("Thumbnail your problem")]
        [Required(ErrorMessage = "Thumbnail Require")]
        [DataType(DataType.Text)]
        public string Thumbnail { get; set; }
    }
}
