﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models.ViewModel
{
    public class ChangeProfileViewModel
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = "Id Required")]
        public string Id { get; set; }

        [DisplayName("UserName")]
        [Required(ErrorMessage = "UserName Required")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "PhoneNumber Required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birthday Required")]
        public DateTime? Birthday { get; set; }
        [Required(ErrorMessage = "Thumbnail Required")]
        public string Thumbnail { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Full Name Required")]
        public string FullName { get; set; }

        public ChangeProfileViewModel()
        {

        }

        public ChangeProfileViewModel(Account account)
        {
            Id = account.Id;
            UserName = account.UserName;
            PhoneNumber = account.PhoneNumber;
            Email = account.Email;
            FullName = account.FullName;
            Birthday = account.Birthday;
            Thumbnail = account.Thumbnail;
            Address = account.Address;
        }
    }
}