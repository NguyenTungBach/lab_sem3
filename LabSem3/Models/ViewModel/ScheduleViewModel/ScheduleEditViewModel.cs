using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel.ScheduleViewModel
{
    public class ScheduleEditViewModel
    {
        [DisplayName("Date Booking")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "DateBoking Required")]
        public DateTime DateBoking { get; set; }

        [DisplayName("Slot Number")]
        [Required(ErrorMessage = "SlotNumber Required")]
        public int SlotNumber { get; set; }

        [DisplayName("Lab Id")]
        public int LabId { get; set; }
        public int Status { get; set; }
        [DisplayName("Instructor Id")]
        public string InstructorId { get; set; }
        public ScheduleEditViewModel()
        {

        }
    }
}