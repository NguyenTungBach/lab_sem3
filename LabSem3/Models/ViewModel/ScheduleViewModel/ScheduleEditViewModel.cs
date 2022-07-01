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
        [Required(ErrorMessage = "DateBoking Required")]
        public DateTime DateBoking { get; set; }
        
        [Required(ErrorMessage = "SlotNumber Required")]
        public int SlotNumber { get; set; }

        public int LabId { get; set; }

        public string InstructorId { get; set; }
        public ScheduleEditViewModel()
        {

        }
    }
}