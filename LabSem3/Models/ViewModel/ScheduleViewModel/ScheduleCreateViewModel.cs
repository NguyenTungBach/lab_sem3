using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel.ScheduleViewModel
{
    public class ScheduleCreateViewModel
    {
        [DisplayName("Start Time")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "StartTime Required")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "EndTime Required")]
        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }

        [DisplayName("Slot Number Array")]
        [Required(ErrorMessage = "SlotNumberArray Required")]
        public String SlotNumberArray { get; set; }

        public int LabId { get; set; }

        public string InstructorId { get; set; }

        public ScheduleCreateViewModel()
        {

        }
        
    }
}