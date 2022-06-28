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
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TypeComplaint> TypeComplaints { get; set; }
        public DbSet<TypeEquipment> TypeEquipments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Complaint>().ToTable("Users");

            modelBuilder.Entity<Complaint>()
                .HasRequired<Account>(s => s.Account)
                .WithMany(s => s.Complaints)
                .HasForeignKey<string>(s => s.AccountId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Lab>()
                .HasRequired<Account>(s => s.Account)
                .WithMany(g => g.Labs)
                .HasForeignKey<string>(s => s.AccountId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasOptional<Department>(s => s.Department)
                .WithRequired(g => g.Hod);

            modelBuilder.Entity<Schedule>()
                .HasRequired<Account>(s => s.Instructor)
                .WithMany(g => g.Schedules)
                .HasForeignKey<string>(s => s.InstructorId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Lab>()
                .HasMany<Schedule>(s => s.Schedules)
                .WithRequired(g => g.Lab)
                .HasForeignKey<int>(s => s.LabId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Lab>()
                .HasRequired<Department>(s => s.Department)
                .WithMany(g => g.Labs)
                .HasForeignKey<int>(s => s.DepartmentId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Lab>()
                .HasMany<Equipment>(s => s.Equipments)
                .WithRequired(g => g.Lab)
                .HasForeignKey<int>(s => s.LabId).WillCascadeOnDelete(false);

            

            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}