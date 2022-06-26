using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel.DepartmentViewModel
{
    public class DepartmentEditViewModel
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = "Id Required")]
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "UserName Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "UserName Required")]
        public string Location { get; set; }
        public string HodId { get; set; }
        public int LabId { get; set; }
        public string AccountId { get; set; }
        public int Status { get; set; }

        public DepartmentEditViewModel()
        {

        }
        public DepartmentEditViewModel(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Location = department.Location;
            Status = department.Status;
            HodId = department.HodId;
            LabId = department.LabId;
            AccountId = department.HodId;
        }
    }
}