using LabSem3.Enum;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DateTime? Birthday { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
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

        //public virtual ICollection<IdentityUserClaim> Claims { get; set; }
        //public virtual ICollection<IdentityUserLogin> Logins { get; set; }
        //public virtual ICollection<IdentityUserRole> UserRoles { get; set; }
    }
}