using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel
{
    public class AccountEditViewModel
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = "Id Required")]
        public string Id { get; set; }

        [DisplayName("UserName")]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Role Required")]
        public string Role { get; set; }

        public AccountEditViewModel(Account account)
        {
            Id = account.Id;
            UserName = account.UserName;
        }
    }
}