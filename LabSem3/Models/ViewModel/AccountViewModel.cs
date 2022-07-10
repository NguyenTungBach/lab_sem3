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

        [DisplayName("Account")]
        [Required(ErrorMessage = "Account Required")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        
        public string FullName { get; set; }
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
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        public string Thumbnail { get; set; }
        public string Address { get; set; }
        
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
            Email = account.Email;
            FullName = account.FullName;
            Thumbnail = account.Thumbnail;
            Status = account.Status;
            Address = account.Address;
            CreatedAt = account.CreatedAt;
            UpdatedAt = account.UpdatedAt;
            DeletedAt = account.DeletedAt;
        }
    }
}