using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel
{
    public class ChangePasswordViewModel
    {
        [DisplayName("Old Password")]
        [Required(ErrorMessage = "Old Password Required")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [DisplayName("New Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Minimum Length must > 6, Max Length < 20")]
        public string NewPassword { get; set; }
        [DisplayName("ComfirmPassword")]
        [Required(ErrorMessage = "ComfirmPassword Required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ComfirmPassword { get; set; }

        public ChangePasswordViewModel()
        {

        }
    }
}