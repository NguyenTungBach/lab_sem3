using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class Account: IdentityUser
    {
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public int LabId { get; set; }
        [ForeignKey("LabId")]
        public List<Lab> Labs { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public int ComplaintId { get; set; }
        [ForeignKey("ComplaintId")]
        public List<Complaint> Complaints { get; set; }

        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public List<Schedule> Schedules { get; set; }
    }
}