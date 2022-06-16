using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class Account: IdentityUser
    {
        public int status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime deletedAt { get; set; }
    }
}