namespace LabSem3.Migrations
{
    using LabSem3.Enum;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LabSem3.Data.LabSem3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LabSem3.Data.LabSem3Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //var roles = new List<IdentityRole>
            //{
            //    new IdentityRole {Name=RoleEnum.ADMIN.ToString()},
            //    new IdentityRole {Name=RoleEnum.HOD.ToString()},
            //    new IdentityRole {Name=RoleEnum.INSTRUCTOR.ToString()},
            //    new IdentityRole {Name=RoleEnum.TECHNICAL_STAFF.ToString()},
            //    new IdentityRole {Name=RoleEnum.STUDENT.ToString()},
            //};
            //roles.ForEach(s => context.Roles.Add(s));
            //context.SaveChanges();
        }
    }
}
