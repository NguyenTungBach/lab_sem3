using LabSem3.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using LabSem3.Models.ViewModel;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LabSem3.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Text)]
        public string Detail { get; set; }
        [DataType(DataType.Text)]
        public string Reason { get; set; }
        [DataType(DataType.Text)]
        public string Solution { get; set; }
        [DataType(DataType.Text)]
        public string Note { get; set; }
        public int Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }

        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public string SupportedId { get; set; }
        [ForeignKey("SupportedId")]
        public virtual Account Supporter { get; set; }

        public int? TypeComplaintId { get; set; }
        [ForeignKey("TypeComplaintId")]
        public virtual TypeComplaint TypeComplaint { get; set; }

        public int? EquipmentId { get; set; }
        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }

        public Complaint()
        {

        }

        public Complaint(ComplaintViewModel complaintViewModel)
        {
            if (!complaintViewModel.EquipmentId.IsNullOrWhiteSpace())
            {
                int result;
                if (Int32.TryParse(complaintViewModel.EquipmentId, out result))
                {
                    this.EquipmentId = result;
                }
            }
            else
            {
                this.EquipmentId = 2;
            }
            this.TypeComplaintId = complaintViewModel.TypeComplaintId;
            this.Title = complaintViewModel.Title;
            this.Detail = complaintViewModel.Detail;
            this.Status = 4;
        }
    }
}