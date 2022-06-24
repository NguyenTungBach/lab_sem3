using LabSem3.Enum;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class Account: IdentityUser
    {
        public Account()
        {
            Status = ((int)AccountStatusEnum.ACTIVE);
            CreatedAt = DateTime.Now;
        }
        public string Thumbnail { get; set; }
        public string Address { get; set; }
        public int? Age { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        public int Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }

        public int? LabId { get; set; }
        [ForeignKey("LabId")]
        public virtual List<Lab> Labs { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public int? ComplaintId { get; set; }
        [ForeignKey("ComplaintId")]
        public virtual List<Complaint> Complaints { get; set; }

        public int? ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}