using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class Lab
    {
        [Key]
        public int Id { get; set; }
        public int Status { get; set; }
        public string Thumbnail { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        
        public int? EquipmentId { get; set; }
        [ForeignKey("EquipmentId")]
        public virtual List<Equipment> Equipments { get; set; }

        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public int? ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public virtual List<Schedule> Schedules { get; set; }
    }
}