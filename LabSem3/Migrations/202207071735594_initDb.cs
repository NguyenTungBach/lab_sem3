namespace LabSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Detail = c.String(),
                        Thumbnail = c.String(),
                        Reason = c.String(),
                        Solution = c.String(),
                        Note = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        AccountId = c.String(nullable: false, maxLength: 128),
                        SupportedId = c.String(maxLength: 128),
                        TypeComplaintId = c.Int(),
                        EquipmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.SupportedId)
                .ForeignKey("dbo.TypeComplaints", t => t.TypeComplaintId)
                .Index(t => t.AccountId)
                .Index(t => t.SupportedId)
                .Index(t => t.TypeComplaintId)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Thumbnail = c.String(),
                        Address = c.String(),
                        Age = c.Int(),
                        Birthday = c.DateTime(),
                        FullName = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        LabId = c.Int(),
                        DepartmentId = c.Int(),
                        ComplaintId = c.Int(),
                        ScheduleId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        HodId = c.String(),
                        LabId = c.Int(),
                        Hod_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Hod_Id)
                .Index(t => t.Hod_Id);
            
            CreateTable(
                "dbo.Labs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        DepartmentId = c.Int(nullable: false),
                        EquipmentId = c.Int(),
                        AccountId = c.String(nullable: false, maxLength: 128),
                        ScheduleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Thumbnail = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        LabId = c.Int(nullable: false),
                        DocumentId = c.Int(),
                        TypeEquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeEquipments", t => t.TypeEquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .ForeignKey("dbo.Labs", t => t.LabId)
                .Index(t => t.LabId)
                .Index(t => t.DocumentId)
                .Index(t => t.TypeEquipmentId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Detail = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        TypeEquipmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeEquipments", t => t.TypeEquipmentId)
                .Index(t => t.TypeEquipmentId);
            
            CreateTable(
                "dbo.TypeEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateBoking = c.DateTime(nullable: false),
                        SlotNumber = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        LabId = c.Int(nullable: false),
                        InstructorId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InstructorId)
                .ForeignKey("dbo.Labs", t => t.LabId)
                .Index(t => t.LabId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TypeComplaints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ComplaintId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Users", "TypeComplaintId", "dbo.TypeComplaints");
            DropForeignKey("dbo.Users", "SupportedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Users", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Users", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Departments", "Hod_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Schedules", "LabId", "dbo.Labs");
            DropForeignKey("dbo.Schedules", "InstructorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Equipments", "LabId", "dbo.Labs");
            DropForeignKey("dbo.Equipments", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "TypeEquipmentId", "dbo.TypeEquipments");
            DropForeignKey("dbo.Equipments", "TypeEquipmentId", "dbo.TypeEquipments");
            DropForeignKey("dbo.Labs", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Labs", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Schedules", new[] { "InstructorId" });
            DropIndex("dbo.Schedules", new[] { "LabId" });
            DropIndex("dbo.Documents", new[] { "TypeEquipmentId" });
            DropIndex("dbo.Equipments", new[] { "TypeEquipmentId" });
            DropIndex("dbo.Equipments", new[] { "DocumentId" });
            DropIndex("dbo.Equipments", new[] { "LabId" });
            DropIndex("dbo.Labs", new[] { "AccountId" });
            DropIndex("dbo.Labs", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "Hod_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "EquipmentId" });
            DropIndex("dbo.Users", new[] { "TypeComplaintId" });
            DropIndex("dbo.Users", new[] { "SupportedId" });
            DropIndex("dbo.Users", new[] { "AccountId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TypeComplaints");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Schedules");
            DropTable("dbo.TypeEquipments");
            DropTable("dbo.Documents");
            DropTable("dbo.Equipments");
            DropTable("dbo.Labs");
            DropTable("dbo.Departments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
        }
    }
}
