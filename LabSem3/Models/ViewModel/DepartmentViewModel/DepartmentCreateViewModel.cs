using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel.DepartmentViewModel
{
    public class DepartmentCreateViewModel
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = "Id Required")]
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "UserName Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location Required")]
        public string Location { get; set; }
        public string HodId { get; set; }
    }
}