namespace LabSem3.Migrations
{
    using LabSem3.Enum;
    using LabSem3.Models;
    using Microsoft.AspNet.Identity;
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
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableName]");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var roles = new List<IdentityRole>
             {
                 new IdentityRole {Name=RoleEnum.ADMIN.ToString()},
                 new IdentityRole {Name=RoleEnum.HOD.ToString()},
                 new IdentityRole {Name=RoleEnum.INSTRUCTOR.ToString()},
                 new IdentityRole {Name=RoleEnum.TECHNICAL_STAFF.ToString()},
                 new IdentityRole {Name=RoleEnum.STUDENT.ToString()}
             };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var admin = new Account
            {
                Id = "985f35a0-32c3-4476-9e28-14ddb97c33fe",
                UserName = "Admin",
                Thumbnail = "https://res.cloudinary.com/sem4-fruitapp/image/upload/v1656997069/sem3-lab/man_2_uqbkzy.png",
                FullName = "MR Admin",
                Birthday = DateTime.Parse("1998-06-02"),
                Address = "Ha Noi",
                Email = "bachntth2010055@fpt.edu.vn",
                PasswordHash = "APoL3ZSJ1sEF9+1DbTtIhny9zUJ4QY8EfkLNQroC7Zsku3uh6TeREnjrnbsuPOyBqQ==",
                SecurityStamp = "073164e1-4029-4461-b688-a48f28f3d56e",
                CreatedAt = DateTime.Now,
                Status = ((int)AccountStatusEnum.ACTIVE)
            };
            context.Users.Add(admin);
            //context.SaveChanges();

            var teachnical = new Account
            {
                Id = "e76f7071-b3f5-4534-bf99-f742e8f166ba",
                UserName = "BachTeachnical",
                Thumbnail = "https://res.cloudinary.com/sem4-fruitapp/image/upload/v1656997069/sem3-lab/man_2_uqbkzy.png",
                FullName = "Nguyen Tung Bach",
                Birthday = DateTime.Parse("1998-06-02"),
                Address = "Ha Noi",
                Email = "megamanbosda@gmail.com",
                PasswordHash = "APSceC0cT3FARylo63i5LZnKHa4amur2UHena83xssHwRflksqA7fENrohYxI2qh0A==",
                SecurityStamp = "52be9763-d51e-4ecc-9dd4-8d4fa1f96de0",
                CreatedAt = DateTime.Now,
                Status = ((int)AccountStatusEnum.ACTIVE)
            };
            context.Users.Add(teachnical);

            var instructor = new Account
            {
                Id = "37f3ebde-4c4c-4c9e-b5a4-09207e0c459f",
                UserName = "KienINSTRUCTOR",
                Thumbnail = "https://res.cloudinary.com/sem4-fruitapp/image/upload/v1656997069/sem3-lab/man_2_uqbkzy.png",
                FullName = "Hoang Trung Kien",
                Birthday = DateTime.Parse("1998-06-02"),
                Address = "Ha Noi",
                Email = "hoangkien3511@gmail.com",
                PasswordHash = "AHqta8CBa2Czza+wyWMr6cZiqudnVs3axF0HsN2w4EOeCv/aqVEIGnx6dvUiWs0k2Q==",
                SecurityStamp = "0fbbb4ae-9867-4c7d-be82-0e233cce5a18",
                CreatedAt = DateTime.Now,
                Status = ((int)AccountStatusEnum.ACTIVE)
            };
            context.Users.Add(instructor);

            var student = new Account
            {
                Id = "cf579deb-021c-48b9-87ba-962117bb2e89",
                UserName = "BachSTUDENT",
                Thumbnail = "https://res.cloudinary.com/sem4-fruitapp/image/upload/v1656997070/sem3-lab/man_pv6uxa.png",
                FullName = "Nguyen Tung Bach",
                Birthday = DateTime.Parse("1998-06-02"),
                Address = "Ha Noi",
                Email = "nguyentungbachholo@gmail.com",
                PasswordHash = "ACKqCAxFhE7o27QSFEkUyjkaoWoXPUyBPdoi0YmRXNnUm9PoDQgKQNtYUAzBovY88w==",
                SecurityStamp = "adfb7b76-2e4c-4568-94bf-ce13c57a870d",
                CreatedAt = DateTime.Now,
                Status = ((int)AccountStatusEnum.ACTIVE)
            };
            context.Users.Add(student);

            var hod1 = new Account()
            {
                Id = "24bf0f99-ed6e-42aa-a723-e4deb44701f7",
                UserName = "BachHOD",
                Thumbnail = "https://res.cloudinary.com/sem4-fruitapp/image/upload/v1656997069/sem3-lab/man_3_pcsx1z.png",
                FullName = "Nguyen Tung Bach",
                Birthday = DateTime.Parse("1998-06-02"),
                Address = "Ha Noi",
                Email = "nguyentungbachhalo@gmail.com",
                PasswordHash = "AGBV5w9sFLrK4UmiEIiAr18meFKX71xJmgPFlURTKNGfplnAnsNpL7JFU1S3+X+9qg==",
                SecurityStamp = "dd9326d7-3f4c-43fd-9f9d-328b54e2d271",
                CreatedAt = DateTime.Now,
                Status = ((int)AccountStatusEnum.ACTIVE)
            };
            context.Users.Add(hod1);
            //context.SaveChanges();

            var hod2 = new Account()
            {
                Id = "25b45644-ca54-4758-8e31-9620afcdaa96",
                UserName = "KienHOD",
                Thumbnail = "https://res.cloudinary.com/sem4-fruitapp/image/upload/v1656997070/sem3-lab/man_1_vo7rqn.png",
                FullName = "Hoang Trung Kien",
                Birthday = DateTime.Parse("1998-06-02"),
                Address = "Ha Noi",
                Email = "kienhtth2012004@fpt.edu.vn",
                PasswordHash = "AObhBDFwccL+DtydEZGEzzqvWERYyxHPU/T74EVQE3ukE5iSyCWSo5rXLdVn8Wd9uA==",
                SecurityStamp = "9ec44d14-0748-4d8e-af2a-d7f8e057bf9e",
                CreatedAt = DateTime.Now,
                Status = ((int)AccountStatusEnum.ACTIVE)
            };
            context.Users.Add(hod2);
            //context.SaveChanges();

            var hod3 = new Account()
            {
                Id = "f25157a3-90ea-4191-afd2-13eb8631d838",
                UserName = "QuyHOD",
                Thumbnail = "https://res.cloudinary.com/sem4-fruitapp/image/upload/v1656997070/sem3-lab/man_1_vo7rqn.png",
                FullName = "Nguyen Van Quy",
                Birthday = DateTime.Parse("1998-06-02"),
                Address = "Ha Noi",
                Email = "quynvth2011013@fpt.edu.vn",
                PasswordHash = "ABzGGqJYuo2Z+P2jueo2sL1EbLJPRQs/1IPc8fU4nvlqjAad9A0v/qES9jQhZyPKVA== ",
                SecurityStamp = "ec3c265a-d735-46c5-9b21-a1828421095b",
                CreatedAt = DateTime.Now,
                Status = ((int)AccountStatusEnum.ACTIVE)
            };
            context.Users.Add(hod3);
            context.SaveChanges();



            var userStore = new UserStore<Account>(context);
            var userManager = new UserManager<Account>(userStore);
            userManager.AddToRole("985f35a0-32c3-4476-9e28-14ddb97c33fe", RoleEnum.ADMIN.ToString());
            userManager.AddToRole("37f3ebde-4c4c-4c9e-b5a4-09207e0c459f", RoleEnum.INSTRUCTOR.ToString());
            userManager.AddToRole("e76f7071-b3f5-4534-bf99-f742e8f166ba", RoleEnum.TECHNICAL_STAFF.ToString());
            userManager.AddToRole("cf579deb-021c-48b9-87ba-962117bb2e89", RoleEnum.STUDENT.ToString());
            userManager.AddToRole("24bf0f99-ed6e-42aa-a723-e4deb44701f7", RoleEnum.HOD.ToString());
            userManager.AddToRole("25b45644-ca54-4758-8e31-9620afcdaa96", RoleEnum.HOD.ToString());
            userManager.AddToRole("f25157a3-90ea-4191-afd2-13eb8631d838", RoleEnum.HOD.ToString());

            var typeComplaints = new List<TypeComplaint>
             {
                 new TypeComplaint {Id = 1, Name = "Software Licenses", TypeRole = RoleEnum.INSTRUCTOR.ToString()},
                 new TypeComplaint {Id = 2, Name = "Equipment Problem", TypeRole = RoleEnum.TECHNICAL_STAFF.ToString() },
                 new TypeComplaint {Id = 3, Name = "Required New Equipment", TypeRole = RoleEnum.ADMIN.ToString()},
                 new TypeComplaint {Id = 4, Name = "Required Extra Lab", TypeRole = RoleEnum.ADMIN.ToString()},
                 new TypeComplaint {Id = 5, Name = "Hygiene And Safety", TypeRole = RoleEnum.TECHNICAL_STAFF.ToString()},
                 new TypeComplaint {Id = 6, Name = "Lab Quality" , TypeRole = RoleEnum.INSTRUCTOR.ToString()},
                 new TypeComplaint {Id = 7, Name = "Comment For Lab Staff" , TypeRole = "GENERAL"},
                 new TypeComplaint {Id = 8, Name = "Other" , TypeRole = "GENERAL"}
             };

            typeComplaints.ForEach(s => context.TypeComplaints.Add(s));
            context.SaveChanges();

            var typeEquipment = new List<TypeEquipment>

             {
                 new TypeEquipment {Id = 1, Name = "Software"},
                 new TypeEquipment {Id = 2, Name = "Head Phone"},
                 new TypeEquipment {Id = 3, Name = "Monitor"},
                 new TypeEquipment {Id = 4, Name = "Case"},
                 new TypeEquipment {Id = 5, Name = "Mouse"},
                 new TypeEquipment {Id = 6, Name = "Keyboard"},
                 new TypeEquipment {Id = 7, Name = "Projecter"},
                 new TypeEquipment {Id = 8, Name = "Screen"},
                 new TypeEquipment {Id = 9, Name = "Fittings"},
                 new TypeEquipment {Id = 10, Name = "Adapter"},
                 new TypeEquipment {Id = 11, Name = "Cable"},
                 new TypeEquipment {Id = 12, Name = "Video and audio switcher"},
                 new TypeEquipment {Id = 13, Name = "Table"},
                 new TypeEquipment {Id = 14, Name = "Chair"},
                 new TypeEquipment {Id = 15, Name = "Light"},
                 new TypeEquipment {Id = 16, Name = "Air Conditioner"},
                 new TypeEquipment {Id = 17, Name = "Other"}
             };


            typeEquipment.ForEach(s => context.TypeEquipments.Add(s));
            context.SaveChanges();

            var departments = new List<Department>
             {
                 new Department {Id= 1, Name="Ha Noi Center", Location="Ha Noi", Status=((int)DepartmentStatusEnum.ACTIVE),CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now, Hod=hod1},
                 new Department {Id= 2, Name="Ho Chi Minh Center", Location="Ho Chi Minh City", Status=((int)DepartmentStatusEnum.ACTIVE),CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now, Hod=hod2},
                 new Department {Id= 3, Name="Da Nang Center", Location="Da Nang", Status=((int)DepartmentStatusEnum.ACTIVE),CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now, Hod=hod3}
             };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var lab = new List<Lab>
            {
                new Lab {Id = 1, Status = 1, Thumbnail="https://res.cloudinary.com/hoangkien0601/image/upload/v1655830520/computer_lab_floorplan_kvfxh7.jpg", AccountId = "985f35a0-32c3-4476-9e28-14ddb97c33fe", DepartmentId = 1,CreatedAt=DateTime.Now,UpdatedAt = DateTime.Now},
                new Lab { Id = 2, Status = 1, Thumbnail = "https://res.cloudinary.com/hoangkien0601/image/upload/v1655830526/LabRoom_nuvzax.jpg", AccountId = "985f35a0-32c3-4476-9e28-14ddb97c33fe", DepartmentId = 1,CreatedAt=DateTime.Now,UpdatedAt = DateTime.Now },
                new Lab { Id = 3, Status = 1, Thumbnail = "https://res.cloudinary.com/hoangkien0601/image/upload/v1655830520/computer_lab_floorplan_kvfxh7.jpg", AccountId = "985f35a0-32c3-4476-9e28-14ddb97c33fe", DepartmentId = 2,CreatedAt=DateTime.Now,UpdatedAt = DateTime.Now },
                new Lab {Id = 4, Status = 1, Thumbnail="https://res.cloudinary.com/hoangkien0601/image/upload/v1655830526/LabRoom_nuvzax.jpg", AccountId = "985f35a0-32c3-4476-9e28-14ddb97c33fe", DepartmentId = 2,CreatedAt=DateTime.Now,UpdatedAt = DateTime.Now},
                new Lab {Id = 5, Status = 1, Thumbnail="https://res.cloudinary.com/hoangkien0601/image/upload/v1655830520/computer_lab_floorplan_kvfxh7.jpg", AccountId = "985f35a0-32c3-4476-9e28-14ddb97c33fe", DepartmentId = 3,CreatedAt=DateTime.Now,UpdatedAt = DateTime.Now},
                new Lab {Id = 6, Status = 1, Thumbnail="https://res.cloudinary.com/hoangkien0601/image/upload/v1655830526/LabRoom_nuvzax.jpg", AccountId = "985f35a0-32c3-4476-9e28-14ddb97c33fe", DepartmentId = 3,CreatedAt=DateTime.Now,UpdatedAt = DateTime.Now},
            };
            lab.ForEach(s => context.Labs.Add(s));
            context.SaveChanges();

            var equipment = new List<Equipment>
            {   
                // Equipment Lab id = 1
                new Equipment{Id = 1, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 2, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 3, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 4, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 5, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 6, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 7, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 8, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 9, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 10, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 11, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 12, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 13, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 14, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 15, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 16, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 17, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 18, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 19, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 20, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 21, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 22, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 23, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 24, Thumbnail="https://vn-live-01.slatic.net/p/0e9e38e9e2304eae2f0ecdf59432572d.jpg",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 25, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 26, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 27, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 28, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 29, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 30, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 31, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 32, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 33, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 34, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 35, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 36, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 37, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 38, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 39, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 40, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 41, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 42, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 43, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 44, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 45, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 46, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 47, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 48, Thumbnail="https://hanoicomputercdn.com/media/product/51506_razer_kraken_kitty_quartz_headset_gaming__2_.png",Name = "Raze HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 49,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 50,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 51,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 52,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 53,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 54,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 55,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 56,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 57,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 58,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 59,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 60,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 61,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 62,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 63,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 64,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 65,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 66,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 67,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 68,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 69,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 70,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 71,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 72,Thumbnail="https://anphat.com.vn/media/lib/21-06-2021/30892_dell_u3219q_70pyr1_1.jpg" ,Name = "Dell Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 73,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 74,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 75,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 76,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 77,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 78,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 79,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 80,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 81,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 82,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 83,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 84,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 85,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 86,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 87,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 88,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 89,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 90,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 91,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 92,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 93,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 94,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 95,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 96,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 97,Thumbnail="https://product.hstatic.net/1000026716/product/thumbchuot_be9a45ef2bec4b7e9dfaf83c2d37ad27.png" ,Name = "Logitech Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 98, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 99, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 100, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 101, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 102, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 103, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 104, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 105, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 106, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 107, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 108, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 109, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 110, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 111, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 112, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 113, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 114, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 115, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 116, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 117, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 118, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 119, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 120, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 121, Thumbnail="https://www.playzone.vn/image/catalog/san%20pham/Logitech/keyboard/g-pro-x/7.jpg",Name = "Logitech KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 122,Thumbnail="https://dienmayxuanminh.com/wp-content/uploads/2019/07/may-lanh-lg-v10enh-1-1-org.jpg" ,Name = "LG AirCondition",TypeEquipmentId=16,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 123,Thumbnail="https://phucanhcdn.com/media/product/30804_b_____pha__t_wifi_asus_gt_ac5300_ac5300mbps_80_user_1.png" ,Name = "Asus WirelesLan",TypeEquipmentId=10,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 124,Thumbnail="https://phucanhcdn.com/media/product/30804_b_____pha__t_wifi_asus_gt_ac5300_ac5300mbps_80_user_1.png" ,Name = "Asus WirelesLan",TypeEquipmentId=10,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 125,Thumbnail="https://phucanhcdn.com/media/product/30804_b_____pha__t_wifi_asus_gt_ac5300_ac5300mbps_80_user_1.png" ,Name = "Asus WirelesLan",TypeEquipmentId=10,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 126,Thumbnail="https://phucanhcdn.com/media/product/30804_b_____pha__t_wifi_asus_gt_ac5300_ac5300mbps_80_user_1.png" ,Name = "Asus WirelesLan",TypeEquipmentId=10,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 127,Thumbnail="https://www.tradeinn.com/f/13826/138265913/viewsonic-ps501x-projector.jpg" ,Name = "ViewSonic Projecter",TypeEquipmentId=7,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 128,Thumbnail="https://maychieuchinhhang.com/wp-content/uploads/2021/06/man-chieu-dien-tu-100.jpg" ,Name = "Screen",TypeEquipmentId=8,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 129,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 130,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 131,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 132,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 133,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 134,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 135,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 136,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 137,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 138,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 139,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 140,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 141,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 142,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 143,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 144,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 145,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 146,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 147,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 148,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 149,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 150,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 151,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 152,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 153,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 154,Thumbnail="https://cdn.tgdd.vn/Files/2021/10/04/1387582/huong-dan-cach-thay-bong-den-huynh-quang-don-gian.jpg" ,Name = "Light Led",TypeEquipmentId=15,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 155,Thumbnail="https://cdn.tgdd.vn/Files/2021/10/04/1387582/huong-dan-cach-thay-bong-den-huynh-quang-don-gian.jpg" ,Name = "Light Led",TypeEquipmentId=15,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 156,Thumbnail="https://cdn.tgdd.vn/Files/2021/10/04/1387582/huong-dan-cach-thay-bong-den-huynh-quang-don-gian.jpg" ,Name = "Light Led",TypeEquipmentId=15,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 157,Thumbnail="https://cdn.tgdd.vn/Files/2021/10/04/1387582/huong-dan-cach-thay-bong-den-huynh-quang-don-gian.jpg" ,Name = "Light Led",TypeEquipmentId=15,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 158,Thumbnail="https://cdn.tgdd.vn/Files/2021/10/04/1387582/huong-dan-cach-thay-bong-den-huynh-quang-don-gian.jpg" ,Name = "Light Led",TypeEquipmentId=15,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 159,Thumbnail="https://cdn.tgdd.vn/Files/2021/10/04/1387582/huong-dan-cach-thay-bong-den-huynh-quang-don-gian.jpg" ,Name = "Light Led",TypeEquipmentId=15,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 160, Thumbnail="https://img.websosanh.vn/v2/users/root_product/images/may-in-laser-den-trang-canon/jc7LqKqDrWGc.jpg",Name = "Color Printer",TypeEquipmentId=16,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 161, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 162, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 163, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 164, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 165, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 166, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 167, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 168, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 169, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 170, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 171, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 172, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 173, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 174, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 175, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 176, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 177, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 178, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 179, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 180, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 181, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 182, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 183, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},
                new Equipment{Id = 184, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=1},

                new Equipment{Id = 300, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 301, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 302, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 303, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 304, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 305, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 306, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 307, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 308, Thumbnail="https://macone.vn/wp-content/uploads/2018/11/2_9_46_1.jpg",Name = "AirPord",TypeEquipmentId=1,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 309, Thumbnail="https://macone.vn/wp-content/uploads/2018/11/2_9_46_1.jpg",Name = "AirPord",TypeEquipmentId=1,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 310, Thumbnail="https://macone.vn/wp-content/uploads/2018/11/2_9_46_1.jpg",Name = "AirPord",TypeEquipmentId=1,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 311, Thumbnail="https://macone.vn/wp-content/uploads/2018/11/2_9_46_1.jpg",Name = "AirPord",TypeEquipmentId=1,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 312, Thumbnail="https://macone.vn/wp-content/uploads/2018/11/2_9_46_1.jpg",Name = "AirPord",TypeEquipmentId=1,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 313, Thumbnail="https://macone.vn/wp-content/uploads/2018/11/2_9_46_1.jpg",Name = "AirPord",TypeEquipmentId=1,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 314,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-imac-24-blue-2_7894affab245407d8b390ff3191bf299.png" ,Name = "IMac 24",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 315,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-imac-24-blue-2_7894affab245407d8b390ff3191bf299.png" ,Name = "IMac 24",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 316,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-imac-24-blue-2_7894affab245407d8b390ff3191bf299.png" ,Name = "IMac 24",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 317,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-imac-24-blue-2_7894affab245407d8b390ff3191bf299.png" ,Name = "IMac 24",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 318,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-imac-24-blue-2_7894affab245407d8b390ff3191bf299.png" ,Name = "IMac 24",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 319,Thumbnail="https://macone.vn/wp-content/uploads/2017/12/Apple-Magic-Mouse-2.-.jpg" ,Name = "Mac Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 320,Thumbnail="https://macone.vn/wp-content/uploads/2017/12/Apple-Magic-Mouse-2.-.jpg" ,Name = "Mac Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 321,Thumbnail="https://macone.vn/wp-content/uploads/2017/12/Apple-Magic-Mouse-2.-.jpg" ,Name = "Mac Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 322,Thumbnail="https://macone.vn/wp-content/uploads/2017/12/Apple-Magic-Mouse-2.-.jpg" ,Name = "Mac Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 323,Thumbnail="https://macone.vn/wp-content/uploads/2017/12/Apple-Magic-Mouse-2.-.jpg" ,Name = "Mac Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 324,Thumbnail="https://macone.vn/wp-content/uploads/2017/12/Apple-Magic-Mouse-2.-.jpg" ,Name = "Mac Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 325,Thumbnail="https://macone.vn/wp-content/uploads/2017/12/Apple-Magic-Mouse-2.-.jpg" ,Name = "Mac Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 326, Thumbnail="https://macone.vn/wp-content/uploads/2022/03/MMMR3.jpeg",Name = "Mac KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 327,Thumbnail="https://phucanhcdn.com/media/product/30804_b_____pha__t_wifi_asus_gt_ac5300_ac5300mbps_80_user_1.png" ,Name = "Asus WirelesLan",TypeEquipmentId=10,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 328,Thumbnail="https://www.tradeinn.com/f/13826/138265913/viewsonic-ps501x-projector.jpg" ,Name = "ViewSonic Projecter",TypeEquipmentId=7,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 329,Thumbnail="https://maychieuchinhhang.com/wp-content/uploads/2021/06/man-chieu-dien-tu-100.jpg" ,Name = "Screen",TypeEquipmentId=8,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 330,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 331,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 332,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 333,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 334,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},
                new Equipment{Id = 335,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=3},


                new Equipment{Id = 200, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 201, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 202, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 203, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 204, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 205, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 206, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 207, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 208, Thumbnail="https://lh3.googleusercontent.com/Ov-36ktIyuTLRbOLQwcD9rCUc44fMhNMowoeWOWVV33kJ4A9LTcuODVMyRcHNIjy9OoNnaWX8gp3-_rXs8EN=w500-rw",Name = "DareU HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 209, Thumbnail="https://lh3.googleusercontent.com/Ov-36ktIyuTLRbOLQwcD9rCUc44fMhNMowoeWOWVV33kJ4A9LTcuODVMyRcHNIjy9OoNnaWX8gp3-_rXs8EN=w500-rw",Name = "DareU HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 210, Thumbnail="https://lh3.googleusercontent.com/Ov-36ktIyuTLRbOLQwcD9rCUc44fMhNMowoeWOWVV33kJ4A9LTcuODVMyRcHNIjy9OoNnaWX8gp3-_rXs8EN=w500-rw",Name = "DareU HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 211, Thumbnail="https://lh3.googleusercontent.com/Ov-36ktIyuTLRbOLQwcD9rCUc44fMhNMowoeWOWVV33kJ4A9LTcuODVMyRcHNIjy9OoNnaWX8gp3-_rXs8EN=w500-rw",Name = "DareU HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 212, Thumbnail="https://lh3.googleusercontent.com/Ov-36ktIyuTLRbOLQwcD9rCUc44fMhNMowoeWOWVV33kJ4A9LTcuODVMyRcHNIjy9OoNnaWX8gp3-_rXs8EN=w500-rw",Name = "DareU HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 213, Thumbnail="https://lh3.googleusercontent.com/Ov-36ktIyuTLRbOLQwcD9rCUc44fMhNMowoeWOWVV33kJ4A9LTcuODVMyRcHNIjy9OoNnaWX8gp3-_rXs8EN=w500-rw",Name = "DareU HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 214,Thumbnail="https://lh3.googleusercontent.com/Ov-36ktIyuTLRbOLQwcD9rCUc44fMhNMowoeWOWVV33kJ4A9LTcuODVMyRcHNIjy9OoNnaWX8gp3-_rXs8EN=w500-rw",Name = "DareU HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 215,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 216,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 217,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 218,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 219,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 220,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 221,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 222,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 223,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 216,Thumbnail="https://hanoicomputercdn.com/media/product/59175_chuot_dareu_em908_arctic_rgb_usb_mau_trang_0001_2.jpg" ,Name = "DareU Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 216,Thumbnail="https://hanoicomputercdn.com/media/product/59175_chuot_dareu_em908_arctic_rgb_usb_mau_trang_0001_2.jpg" ,Name = "DareU Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 216,Thumbnail="https://hanoicomputercdn.com/media/product/59175_chuot_dareu_em908_arctic_rgb_usb_mau_trang_0001_2.jpg" ,Name = "DareU Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 216,Thumbnail="https://hanoicomputercdn.com/media/product/59175_chuot_dareu_em908_arctic_rgb_usb_mau_trang_0001_2.jpg" ,Name = "DareU Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 217, Thumbnail="https://product.hstatic.net/1000026716/product/asus-rog-strix-scope-tkl-gundam_be1edaf2d9474c42840a29e54c77838b.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 218, Thumbnail="https://product.hstatic.net/1000026716/product/asus-rog-strix-scope-tkl-gundam_be1edaf2d9474c42840a29e54c77838b.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 219, Thumbnail="https://product.hstatic.net/1000026716/product/asus-rog-strix-scope-tkl-gundam_be1edaf2d9474c42840a29e54c77838b.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 220, Thumbnail="https://product.hstatic.net/1000026716/product/asus-rog-strix-scope-tkl-gundam_be1edaf2d9474c42840a29e54c77838b.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 221,Thumbnail="https://phucanhcdn.com/media/product/30804_b_____pha__t_wifi_asus_gt_ac5300_ac5300mbps_80_user_1.png" ,Name = "Asus Adapter",TypeEquipmentId=10,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 222,Thumbnail="https://www.tradeinn.com/f/13826/138265913/viewsonic-ps501x-projector.jpg" ,Name = "ViewSonic Projecter",TypeEquipmentId=7,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 223,Thumbnail="https://maychieuchinhhang.com/wp-content/uploads/2021/06/man-chieu-dien-tu-100.jpg" ,Name = "Screen",TypeEquipmentId=8,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 224,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},
                new Equipment{Id = 225, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=2},

                new Equipment{Id = 400, Thumbnail="https://pcmarket.vn/media/product/8268_6154_71971776_1136012033255006_9026511231590072320_o.jpg",Name = "Chair Asus",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 401, Thumbnail="https://pcmarket.vn/media/product/8268_6154_71971776_1136012033255006_9026511231590072320_o.jpg",Name = "Chair Asus",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 402, Thumbnail="https://pcmarket.vn/media/product/8268_6154_71971776_1136012033255006_9026511231590072320_o.jpg",Name = "Chair Asus",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 403, Thumbnail="https://pcmarket.vn/media/product/8268_6154_71971776_1136012033255006_9026511231590072320_o.jpg",Name = "Chair Asus",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 404, Thumbnail="https://pcmarket.vn/media/product/8268_6154_71971776_1136012033255006_9026511231590072320_o.jpg",Name = "Chair Asus",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 405, Thumbnail="https://pcmarket.vn/media/product/8268_6154_71971776_1136012033255006_9026511231590072320_o.jpg",Name = "Chair Asus",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 406, Thumbnail="https://pcmarket.vn/media/product/8268_6154_71971776_1136012033255006_9026511231590072320_o.jpg",Name = "Chair Asus",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 407, Thumbnail="https://product.hstatic.net/1000026716/product/h732__2__46d3cb8ea64749379d6357f6d4316199.png",Name = "Asus HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 408, Thumbnail="https://product.hstatic.net/1000026716/product/h732__2__46d3cb8ea64749379d6357f6d4316199.png",Name = "Asus HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 409, Thumbnail="https://product.hstatic.net/1000026716/product/h732__2__46d3cb8ea64749379d6357f6d4316199.png",Name = "Asus HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 410, Thumbnail="https://product.hstatic.net/1000026716/product/h732__2__46d3cb8ea64749379d6357f6d4316199.png",Name = "Asus HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 411, Thumbnail="https://product.hstatic.net/1000026716/product/h732__2__46d3cb8ea64749379d6357f6d4316199.png",Name = "Asus HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 412, Thumbnail="https://product.hstatic.net/1000026716/product/h732__2__46d3cb8ea64749379d6357f6d4316199.png",Name = "Asus HeadPhone",TypeEquipmentId=2,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 413,Thumbnail="https://product.hstatic.net/1000026716/product/xg279q-g_gundam_edition_8807f319c8ae4a71869d1fa45974982e.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 414,Thumbnail="https://product.hstatic.net/1000026716/product/xg279q-g_gundam_edition_8807f319c8ae4a71869d1fa45974982e.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 415,Thumbnail="https://product.hstatic.net/1000026716/product/xg279q-g_gundam_edition_8807f319c8ae4a71869d1fa45974982e.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 416,Thumbnail="https://product.hstatic.net/1000026716/product/xg279q-g_gundam_edition_8807f319c8ae4a71869d1fa45974982e.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 417,Thumbnail="https://product.hstatic.net/1000026716/product/xg279q-g_gundam_edition_8807f319c8ae4a71869d1fa45974982e.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 418,Thumbnail="https://product.hstatic.net/1000026716/product/xg279q-g_gundam_edition_8807f319c8ae4a71869d1fa45974982e.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 419,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn.com-products-chuot-asus-rog-gladius-iii-wireless-4_dd98072539e94850a8a0b127e538c7e3.jpg" ,Name = "Asus Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 420,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn.com-products-chuot-asus-rog-gladius-iii-wireless-4_dd98072539e94850a8a0b127e538c7e3.jpg" ,Name = "Asus Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 421,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn.com-products-chuot-asus-rog-gladius-iii-wireless-4_dd98072539e94850a8a0b127e538c7e3.jpg" ,Name = "Asus Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 422,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn.com-products-chuot-asus-rog-gladius-iii-wireless-4_dd98072539e94850a8a0b127e538c7e3.jpg" ,Name = "Asus Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 423,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn.com-products-chuot-asus-rog-gladius-iii-wireless-4_dd98072539e94850a8a0b127e538c7e3.jpg" ,Name = "Asus Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 424,Thumbnail="https://product.hstatic.net/1000026716/product/gearvn.com-products-chuot-asus-rog-gladius-iii-wireless-4_dd98072539e94850a8a0b127e538c7e3.jpg" ,Name = "Asus Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 425, Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-ban-phim-co-asus-rog-strix-scope-rx-eva-edition-1_70577e72c5ce4b129ac8bbe7f2516c63.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 426, Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-ban-phim-co-asus-rog-strix-scope-rx-eva-edition-1_70577e72c5ce4b129ac8bbe7f2516c63.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 427, Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-ban-phim-co-asus-rog-strix-scope-rx-eva-edition-1_70577e72c5ce4b129ac8bbe7f2516c63.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 428, Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-ban-phim-co-asus-rog-strix-scope-rx-eva-edition-1_70577e72c5ce4b129ac8bbe7f2516c63.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 429, Thumbnail="https://product.hstatic.net/1000026716/product/gearvn-ban-phim-co-asus-rog-strix-scope-rx-eva-edition-1_70577e72c5ce4b129ac8bbe7f2516c63.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 430,Thumbnail="https://phucanhcdn.com/media/product/30804_b_____pha__t_wifi_asus_gt_ac5300_ac5300mbps_80_user_1.png" ,Name = "Asus Adapter",TypeEquipmentId=10,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 431,Thumbnail="https://www.tradeinn.com/f/13826/138265913/viewsonic-ps501x-projector.jpg" ,Name = "ViewSonic Projecter",TypeEquipmentId=7,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 432,Thumbnail="https://maychieuchinhhang.com/wp-content/uploads/2021/06/man-chieu-dien-tu-100.jpg" ,Name = "Screen",TypeEquipmentId=8,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 433,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 434,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 435,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 436,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 437,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 438,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 439, Thumbnail="https://hugotech.vn/wp-content/uploads/f435-600x600.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 440, Thumbnail="https://hugotech.vn/wp-content/uploads/f435-600x600.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 441, Thumbnail="https://hugotech.vn/wp-content/uploads/f435-600x600.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 442, Thumbnail="https://hugotech.vn/wp-content/uploads/f435-600x600.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 443, Thumbnail="https://hugotech.vn/wp-content/uploads/f435-600x600.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},
                new Equipment{Id = 444, Thumbnail="https://hugotech.vn/wp-content/uploads/f435-600x600.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=4},

                new Equipment{Id = 500, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},
                new Equipment{Id = 501, Thumbnail="https://lh3.googleusercontent.com/Ov-36ktIyuTLRbOLQwcD9rCUc44fMhNMowoeWOWVV33kJ4A9LTcuODVMyRcHNIjy9OoNnaWX8gp3-_rXs8EN=w500-rw",Name = "DareU HeadPhone",TypeEquipmentId=1,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},
                new Equipment{Id = 502,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},
                new Equipment{Id = 503,Thumbnail="https://hanoicomputercdn.com/media/product/59175_chuot_dareu_em908_arctic_rgb_usb_mau_trang_0001_2.jpg" ,Name = "DareU Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},
                new Equipment{Id = 504, Thumbnail="https://product.hstatic.net/1000026716/product/asus-rog-strix-scope-tkl-gundam_be1edaf2d9474c42840a29e54c77838b.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},
                new Equipment{Id = 505,Thumbnail="https://phucanhcdn.com/media/product/30804_b_____pha__t_wifi_asus_gt_ac5300_ac5300mbps_80_user_1.png" ,Name = "Asus WirelesLan",TypeEquipmentId=10,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},
                new Equipment{Id = 506,Thumbnail="https://www.tradeinn.com/f/13826/138265913/viewsonic-ps501x-projector.jpg" ,Name = "ViewSonic Projecter",TypeEquipmentId=7,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},
                new Equipment{Id = 507,Thumbnail="https://maychieuchinhhang.com/wp-content/uploads/2021/06/man-chieu-dien-tu-100.jpg" ,Name = "Screen",TypeEquipmentId=8,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},
                new Equipment{Id = 508,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},
                new Equipment{Id = 509, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=5},

                new Equipment{Id = 600, Thumbnail="https://cdn.shopify.com/s/files/1/1640/2231/collections/collection-titan-series_grande.png?v=1580878311",Name = "Chair SecretLab",TypeEquipmentId=14,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},
                new Equipment{Id = 601, Thumbnail="https://lh3.googleusercontent.com/Ov-36ktIyuTLRbOLQwcD9rCUc44fMhNMowoeWOWVV33kJ4A9LTcuODVMyRcHNIjy9OoNnaWX8gp3-_rXs8EN=w500-rw",Name = "DareU HeadPhone",TypeEquipmentId=1,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},
                new Equipment{Id = 602,Thumbnail="https://cdn.tgdd.vn/Products/Images/5697/253750/asus-lcd-vy249he-238-fulhd-600x600.jpg" ,Name = "Asus Desktop",TypeEquipmentId=3,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},
                new Equipment{Id = 603,Thumbnail="https://hanoicomputercdn.com/media/product/59175_chuot_dareu_em908_arctic_rgb_usb_mau_trang_0001_2.jpg" ,Name = "DareU Mouse",TypeEquipmentId=5,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},
                new Equipment{Id = 604, Thumbnail="https://product.hstatic.net/1000026716/product/asus-rog-strix-scope-tkl-gundam_be1edaf2d9474c42840a29e54c77838b.png",Name = "Asus KeyBoard",TypeEquipmentId=6,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},
                new Equipment{Id = 605,Thumbnail="https://phucanhcdn.com/media/product/30804_b_____pha__t_wifi_asus_gt_ac5300_ac5300mbps_80_user_1.png" ,Name = "Asus Adapter",TypeEquipmentId=10,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},
                new Equipment{Id = 606,Thumbnail="https://www.tradeinn.com/f/13826/138265913/viewsonic-ps501x-projector.jpg" ,Name = "ViewSonic Projecter",TypeEquipmentId=7,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},
                new Equipment{Id = 607,Thumbnail="https://maychieuchinhhang.com/wp-content/uploads/2021/06/man-chieu-dien-tu-100.jpg" ,Name = "Screen",TypeEquipmentId=8,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},
                new Equipment{Id = 608,Thumbnail="https://salt.tikicdn.com/ts/tmp/c9/ab/25/0ab43d2de77597a75d9857caf59e53d2.jpg" ,Name = "Table",TypeEquipmentId=13,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},
                new Equipment{Id = 609, Thumbnail="https://hacom.vn/media/news/2704_vcasemytnh.jpg",Name = "Case Asus",TypeEquipmentId=4,Status=(int)EquipmentStatusEnum.GOOD,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now,LabId=6},

            };
            equipment.ForEach(s => context.Equipments.Add(s));
            context.SaveChanges();



            var document = new List<Document>
        {
            new Document {Id = 1, Status = ((int)DocumentStatusEnum.AVAILABLE), Title="Guilded HeadPhone", Detail="Determine the left and right sides of the in-ear headphones. You can usually find “L” and “R” markings on each side which suggests the proper orientation.,With the proper orientation in check, put on the in-ear headphones. Place each ear tip on the corresponding side of your head. Pull your earlobe with the other hand to create enough space to gently push the ear tip inside your ear canal.,Depending on your personal preference, position the wire in front or behind you.,With these tips and detailed instructions in mind, you should now be able to wear your headphones comfortably for the best listening experience. Not only are you able to wear headphones the way they were intended to be worn, but you should also know what to look out for to reduce overall discomfort when wearing them.,How’d you like our detailed guide? What’s your favorite type of headphones? Are you still having trouble putting them on? Please feel free to let us know in the comments down below!",TypeEquipmentId=2,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            new Document {Id = 2 ,Status = ((int)DocumentStatusEnum.AVAILABLE), Title="Guilded Desktop", Detail="Set up your computer. If you are setting up a new desktop computer, there are a few steps you will need to go through before you can start using it. After finding a place near your desk to put the tower, you will need to connect your monitor, keyboard, and mouse, as well as plug the tower into a power source.,Create an account. If it's your first time turning on a brand new computer, you'll usually be asked to create an account. This account will hold all of your documents, pictures, downloaded files, and any other files that you create.,Learn mouse and keyboard basics. The mouse and keyboard are your primary means of interacting with your computer. Take some time to get familiar with how they work and how you can interact with your operating system and programs.,Loop the wire over your ear and secure it snugly in place.,After looping the wire over your ear, position the rest of the wire in front or behind you depending on your personal preference.,No matter how expensive or high quality your headphones are, it means nothing if it doesn’t even fit you well. Although this tip mostly applies to in-ear headphones with replaceable ear tips, it helps to be aware of the importance of having a proper fit for other types of headphones as well.,It’s not advisable to wear earrings or other ear piercings when wearing headphones as not only will these cause discomfort or pain, but these objects can also damage the ear cups or headphone padding.",TypeEquipmentId=3,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            new Document {Id = 3, Status = ((int)DocumentStatusEnum.AVAILABLE),Title="Guilded Mouse", Detail="Today's computer mouse consists of two buttons and a mouse wheel as shown in the picture below. By default, the left button acts as the left-click and is the default mouse button you use for most actions on the mouse. The right mouse button performs the right-click and gives you a menu or other options that are explained later.,To hold the mouse, keep your thumb on the side of the mouse, index finger on the left button, and middle finger on the right button. While holding the mouse relax your hand and make sure your hand is straight with your arm. You should never have your wrist at an angle while using the mouse.,Using your right or left hand, pick up the mouse and move it to the center of the mouse pad. Once in position, drag the mouse up, down, left, or right to move the mouse pointer on the screen. If you reach the edge of your mouse pad, pick up the mouse and move it to the opposite side of the mouse pad. Then, continue dragging the mouse in the direction you want the mouse pointer to move.",TypeEquipmentId=5,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            new Document {Id = 4, Status = ((int)DocumentStatusEnum.AVAILABLE), Title="Guilded Microsoft Office", Detail= "The latest version of Microsoft Office is called Microsoft Office 2019, although the web-based Microsoft 365 is the version that Microsoft would prefer users to adopt. Various versions of the suite have been around since 1988, including but not limited to Microsoft Office Professional, Microsoft Office Home and Student, and various collections of Microsoft Office 2016. Most people still refer to any version of the suite as Microsoft Office, though, which makes distinguishing among editions difficult.,What makes Microsoft 365 stand out from older editions of MS Office is that it integrates all aspects of the apps with the cloud. It’s a subscription service, too, which means users pay a monthly or yearly fee to use it, and upgrades to newer versions are included in this price. Previous versions of Microsoft Office, including Office 2016, didn’t offer all the cloud features that Microsoft 365 does and were not subscription-based. Office 2016 was a one-time purchase, just as other editions were, and as Office 2019 is.,Microsoft 365 Business comes in four different packages: Basic, Standard, Premium, and Apps.,Users who purchase a Microsoft Office suite typically do so when they discover that the apps included with their operating system aren’t robust enough to meet their needs. For example, it would be nearly impossible to write a book using only Microsoft WordPad, the word processing app that is included free with all editions of Windows. But it would certainly be feasible to write a book with Microsoft Word, which offers many more features.",TypeEquipmentId=1,CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now }
        };
            document.ForEach(s => context.Document.Add(s));
            context.SaveChanges();

            var complaints = new List<Complaint>
            {
                new Complaint {Id = 1, Title = "Complaint 001", Detail="Test Complaint",EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 1},
                new Complaint {Id = 2, Title = "Complaint 002", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 1},
                new Complaint {Id = 3, Title = "Complaint 003", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 2},
                new Complaint {Id = 4, Title = "Complaint 004", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 2},
                new Complaint {Id = 5, Title = "Complaint 005", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 2},
                new Complaint {Id = 6, Title = "Complaint 006", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 3},
                new Complaint {Id = 7, Title = "Complaint 007", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 3},
                new Complaint {Id = 8, Title = "Complaint 008", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 3},
                new Complaint {Id = 9, Title = "Complaint 009", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 4},
                new Complaint {Id = 10, Title = "Complaint 010", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 4},
                new Complaint {Id = 11, Title = "Complaint 011", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 1},
                new Complaint {Id = 12, Title = "Complaint 012", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 1},
                new Complaint {Id = 13, Title = "Complaint 013", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 2},
                new Complaint {Id = 14, Title = "Complaint 014", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 2},
                new Complaint {Id = 15, Title = "Complaint 015", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 2},
                new Complaint {Id = 16, Title = "Complaint 016", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 3},
                new Complaint {Id = 17, Title = "Complaint 017", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 3},
                new Complaint {Id = 18, Title = "Complaint 018", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 3},
                new Complaint {Id = 19, Title = "Complaint 019", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 4},
                new Complaint {Id = 20, Title = "Complaint 020", Detail="Test Complaint", EquipmentId = 1, TypeComplaintId = 1, AccountId = "f25157a3-90ea-4191-afd2-13eb8631d838",
                    Status  = 4}
            };
            complaints.ForEach(s => context.Complaints.Add(s));
            context.SaveChanges();
        }
    }
}
