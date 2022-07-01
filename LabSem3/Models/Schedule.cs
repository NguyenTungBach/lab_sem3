using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateBoking { get; set; }
        public int SlotNumber { get; set; }

        public int Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }

        public int LabId { get; set; }
        [ForeignKey("LabId")]
        public Lab Lab { get; set; }

        public string InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public Account Instructor { get; set; }
    }
}