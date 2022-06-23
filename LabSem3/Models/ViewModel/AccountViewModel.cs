using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel
{
    public class AccountViewModel
    {
        [DisplayName("Id")]
        public string Id { get; set; }

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

        [Required(ErrorMessage = "Role Required")]
        public string Role { get; set; }

        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public AccountViewModel()
        {

        }

        public AccountViewModel(Account account)
        {
            Id = account.Id;
            UserName = account.UserName;
            Status = account.Status;
            CreatedAt = account.CreatedAt;
            UpdatedAt = account.UpdatedAt;
            DeletedAt = account.DeletedAt;
        }
    }
}