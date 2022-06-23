namespace LabSem3.Migrations
{
    using LabSem3.Enum;
    using LabSem3.Models;
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

            var roles = new List<IdentityRole>
             {
                 new IdentityRole {Name=RoleEnum.ADMIN.ToString()},
                 new IdentityRole {Name=RoleEnum.HOD.ToString()},
                 new IdentityRole {Name=RoleEnum.INSTRUCTOR.ToString()},
                 new IdentityRole {Name=RoleEnum.TECHNICAL_STAFF.ToString()},
                 new IdentityRole {Name=RoleEnum.STUDENT.ToString()},
                 new IdentityRole {Name=RoleEnum.WAITING.ToString()},
             };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var users = new List<Account>
             {
                 new Account {UserName="Admin", PasswordHash="89B8B8E486421463D7E0F5CAF60FB9CB35CE169B76E657AB21FC4D1D6B093603",CreatedAt=DateTime.Now, Status=((int)AccountStatusEnum.ACTIVE)},
             };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var typeComplaints = new List<TypeComplaint>
             {
                 new TypeComplaint {Id = 1, Name = "Software Licenses"},
                 new TypeComplaint {Id = 2, Name = "Equipment Problem"},
                 new TypeComplaint {Id = 3, Name = "Required New Equipment"},
                 new TypeComplaint {Id = 4, Name = "Required Extra Lab"},
                 new TypeComplaint {Id = 5, Name = "Hygiene And Safety"},
                 new TypeComplaint {Id = 6, Name = "Lab Quality"},
                 new TypeComplaint {Id = 7, Name = "Comment For Lab Staff"},
                 new TypeComplaint {Id = 8, Name = "Other"}
             };

            typeComplaints.ForEach(s => context.TypeComplaints.Add(s));
            context.SaveChanges();

            var typeEquipment = new List<TypeEquipment>
             {
                 new TypeEquipment {Id = 1, Name = "Software"},
                 new TypeEquipment {Id = 2, Name = "Head Phone"},
                 new TypeEquipment {Id = 3, Name = "Desktop"},
                 new TypeEquipment {Id = 4, Name = "Case"},
                 new TypeEquipment {Id = 5, Name = "Mouse"},
                 new TypeEquipment {Id = 6, Name = "Key Board"},
                 new TypeEquipment {Id = 7, Name = "Projecter"},
                 new TypeEquipment {Id = 8, Name = "Screen"},
                 new TypeEquipment {Id = 8, Name = "Air Conditioner"},
                 new TypeEquipment {Id = 9, Name = "Fittings"},
                 new TypeEquipment {Id = 10, Name = "Wireless LAN"},
                 new TypeEquipment {Id = 11, Name = "Cable"},
                 new TypeEquipment {Id = 12, Name = "Video and audio switcher"},
                 new TypeEquipment {Id = 13, Name = "Table"},
                 new TypeEquipment {Id = 14, Name = "Chair"},
                 new TypeEquipment {Id = 15, Name = "Light"},
                 new TypeEquipment {Id = 16, Name = "Other"}
             };

            typeEquipment.ForEach(s => context.TypeEquipments.Add(s));
            context.SaveChanges();

            var departments = new List<Department>
             {
                 new Department {Id= 1, Name="Ha Noi Center", Location="Ha Noi", Status=((int)DepartmentStatusEnum.ACTIVE),CreatedAt=DateTime.Now},
                 new Department {Id= 2, Name="Ho Chi Minh Center", Location="Ho Chi Minh City", Status=((int)DepartmentStatusEnum.ACTIVE),CreatedAt=DateTime.Now},
                 new Department {Id= 3, Name="Da Nang Center", Location="Da Nang", Status=((int)DepartmentStatusEnum.ACTIVE),CreatedAt=DateTime.Now}
             };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var Lab = new List<Lab>
            {
                new Lab {Id = 1, Status = 1, AccountId = "81e0dd67-52b9-4cdf-a1f1-e65a40ccc9d7", DepartmentId = 1},
                new Lab {Id = 2, Status = 2, AccountId = "81e0dd67-52b9-4cdf-a1f1-e65a40ccc9d7", DepartmentId = 2},
                new Lab {Id = 3, Status = 3, AccountId = "81e0dd67-52b9-4cdf-a1f1-e65a40ccc9d7", DepartmentId = 3},
                new Lab {Id = 4, Status = 4, AccountId = "81e0dd67-52b9-4cdf-a1f1-e65a40ccc9d7", DepartmentId = 2}
            };

            Lab.ForEach(s => context.Labs.Add(s));
            context.SaveChanges();

            var Equipment = new List<Equipment>
            {
                new Equipment { Id = 1, Name = "Student stations" , Status = 1, TypeEquipmentId = 1, LabId =2},
                new Equipment { Id = 2, Name = "Management Station", Status = 2, TypeEquipmentId = 1, LabId =2},
                new Equipment { Id = 3, Name = "Server", Status = 3, TypeEquipmentId = 1,LabId =2},
                new Equipment { Id = 4, Name = "Switch", Status = 4, TypeEquipmentId = 1, LabId =2},
                new Equipment { Id = 5, Name = "Other equipme", Status = 5,TypeEquipmentId = 1, LabId =2 }
            };

            Equipment.ForEach(s => context.Equipments.Add(s));
            context.SaveChanges();
        }
    }
}
