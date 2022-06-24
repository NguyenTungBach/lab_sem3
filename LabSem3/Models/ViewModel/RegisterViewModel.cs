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
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Minimum Length must > 6, Max Length < 20")]
        public string Password { get; set; }
        [DisplayName("ComfirmPassword")]
        [Required(ErrorMessage = "ComfirmPassword Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ComfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        public string Thumbnail { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
    }
}