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
        
        public DateTime DateBoking { get; set; }
        public int SlotNumber { get; set; }

        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int LabId { get; set; }
        [ForeignKey("LabId")]
        public Lab Lab { get; set; }

        public string InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public Account Instructor { get; set; }
    }
}