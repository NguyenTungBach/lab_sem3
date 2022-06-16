using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabSem3.Data
{
    public class LabSem3Context: IdentityDbContext<IdentityUser>
    {
        public LabSem3Context() : base("name=LabSem3DB")
        {
        }
    }
}