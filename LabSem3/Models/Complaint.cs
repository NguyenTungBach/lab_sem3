﻿using LabSem3.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
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
    }
}