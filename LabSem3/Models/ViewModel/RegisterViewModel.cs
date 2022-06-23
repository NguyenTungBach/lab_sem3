using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel
{
    public class RegisterViewModel
    {
        [DisplayName("UserName")]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public string Birthday { get; set; }
        public string Thumbnail { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public int Status { get; set; }

        
    }
}