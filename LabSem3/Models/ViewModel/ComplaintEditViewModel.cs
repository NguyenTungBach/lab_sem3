using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel
{
    public class ComplaintEditViewModel
    {
        [Required(ErrorMessage = "Id Require")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title Require")]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Detail Require")]
        public string Detail { get; set; }
        [Required(ErrorMessage = "Reason Require")]
        public string Reason { get; set; }
        [Required(ErrorMessage = "Solution Require")]
        public string Solution { get; set; }
        [Required(ErrorMessage = "Note Require")]
        public string Note { get; set; }
        public string AccountUserName { get; set; }
        public string SupportedId { get; set; }
        [DisplayName("ID Of Equipment")]
        [Required(ErrorMessage = "EquipmentId Require")]
        [CanBeNull]
        public string EquipmentName { get; set; }
        [Required(ErrorMessage = "Status Require")]
        public int Status { get; set; }
        [DisplayName("Type of complaint")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [Required(ErrorMessage = "TypeComplaintId Require")]
        public int TypeComplaintId { get; set; }
        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "Thumbnail Require")]
        [DataType(DataType.Text)]
        public string Thumbnail { get; set; }
    }
}