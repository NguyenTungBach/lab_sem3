using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel.ScheduleViewModel
{
    public class ScheduleEditViewModel
    {
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "StartTime Required")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "EndTime Required")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "SlotNumberArray Required")]
        public String SlotNumberArray { get; set; }

        public int LabId { get; set; }

        public string InstructorId { get; set; }
        public ScheduleEditViewModel()
        {

        }
    }
}