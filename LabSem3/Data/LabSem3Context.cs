using LabSem3.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LabSem3.Data
{
    public class LabSem3Context: IdentityDbContext<Account>
    {
        public LabSem3Context() : base("name=LabSem3DB")
        {
        }
        public DbSet<Complaint> Complaints { get; set; }
    }
}