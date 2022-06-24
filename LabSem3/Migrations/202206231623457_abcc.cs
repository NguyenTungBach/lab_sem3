namespace LabSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abcc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Detail = c.String(),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Accounts", t => t.SupportedId)
                .ForeignKey("dbo.TypeComplaints", t => t.TypeComplaintId)
                .Index(t => t.AccountId)
                .Index(t => t.SupportedId)
                .Index(t => t.TypeComplaintId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Thumbnail = c.String(),
                        Address = c.String(),
                        Age = c.Int(),
                        Birthday = c.DateTime(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        LabId = c.Int(),
                        DepartmentId = c.Int(),
                        ComplaintId = c.Int(),
                        ScheduleId = c.Int(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Account_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
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
                        HodId = c.String(maxLength: 128),
                        LabId = c.Int(nullable: false),
                        AccountId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Accounts", t => t.HodId)
                .Index(t => t.HodId)
                .Index(t => t.AccountId);
            
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
                .ForeignKey("dbo.Accounts", t => t.AccountId)
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
                        TypeEquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeEquipments", t => t.TypeEquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.Labs", t => t.LabId)
                .Index(t => t.LabId)
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
                .ForeignKey("dbo.Accounts", t => t.InstructorId)
                .ForeignKey("dbo.Labs", t => t.LabId)
                .Index(t => t.LabId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Account_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Account_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.IdentityRole_Id);
            
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
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Documents", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Complaints", "TypeComplaintId", "dbo.TypeComplaints");
            DropForeignKey("dbo.Complaints", "SupportedId", "dbo.Accounts");
            DropForeignKey("dbo.Complaints", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.IdentityUserRoles", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.IdentityUserLogins", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Schedules", "LabId", "dbo.Labs");
            DropForeignKey("dbo.Schedules", "InstructorId", "dbo.Accounts");
            DropForeignKey("dbo.Equipments", "LabId", "dbo.Labs");
            DropForeignKey("dbo.Equipments", "TypeEquipmentId", "dbo.TypeEquipments");
            DropForeignKey("dbo.Labs", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Labs", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Departments", "HodId", "dbo.Accounts");
            DropForeignKey("dbo.Departments", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.IdentityUserClaims", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Documents", new[] { "EquipmentId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "Account_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "Account_Id" });
            DropIndex("dbo.Schedules", new[] { "InstructorId" });
            DropIndex("dbo.Schedules", new[] { "LabId" });
            DropIndex("dbo.Equipments", new[] { "TypeEquipmentId" });
            DropIndex("dbo.Equipments", new[] { "LabId" });
            DropIndex("dbo.Labs", new[] { "AccountId" });
            DropIndex("dbo.Labs", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "AccountId" });
            DropIndex("dbo.Departments", new[] { "HodId" });
            DropIndex("dbo.IdentityUserClaims", new[] { "Account_Id" });
            DropIndex("dbo.Accounts", new[] { "DepartmentId" });
            DropIndex("dbo.Complaints", new[] { "TypeComplaintId" });
            DropIndex("dbo.Complaints", new[] { "SupportedId" });
            DropIndex("dbo.Complaints", new[] { "AccountId" });
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Documents");
            DropTable("dbo.TypeComplaints");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.Schedules");
            DropTable("dbo.TypeEquipments");
            DropTable("dbo.Equipments");
            DropTable("dbo.Labs");
            DropTable("dbo.Departments");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.Accounts");
            DropTable("dbo.Complaints");
        }
    }
}
