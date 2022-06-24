using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel
{
    public class LoginViewModel
    {
        [DisplayName("UserName")]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Minimum Length must > 6, Max Length < 20")]
        public string Password { get; set; }
    }
}