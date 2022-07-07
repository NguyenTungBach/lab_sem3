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
        [DisplayName("Title")]
        public string Title { get; set; }
        public string Detail { get; set; }
        [Required(ErrorMessage = "Reason Require")]
        public string Reason { get; set; }
        [Required(ErrorMessage = "Solution Require")]
        public string Solution { get; set; }
        public string Note { get; set; }
        public string AccountUserName { get; set; }
        public string SupportedId { get; set; }
        
        public string EquipmentName { get; set; }
        [Required(ErrorMessage = "Status Require")]
        public int Status { get; set; }
        
        public int TypeComplaintId { get; set; }
        
        public string Thumbnail { get; set; }
        public ComplaintEditViewModel()
        {

        }
    }
}