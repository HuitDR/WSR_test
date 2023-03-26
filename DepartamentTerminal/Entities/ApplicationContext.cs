using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentTerminal.Entities
{
    class ApplicationContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VisitingIndividual> VisitingIndividuals { get; set; }
        public DbSet<VisitingGroup> VisitingGroups { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<BlackList> BlackLists { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(ent =>
            {
                ent.ToTable("Guests");
                ent.HasKey(ent => ent.Id);
                ent.HasIndex(ent => ent.Login).IsUnique();
                ent.HasIndex(ent => ent.Passport).IsUnique();
            });

            modelBuilder.Entity<Employee>(ent =>
            {
                
                ent.HasKey(e => e.EmployeeId);
                ent.HasIndex(ents => ents.EmployeeCode).IsUnique();
                ent.HasOne(ents => ents.Departament).WithMany().HasForeignKey("DepartamentId");
                ent.ToTable("Employees");
            });
            
            modelBuilder.Entity<Status>(ent =>
            {
                ent.ToTable("Status");
                ent.HasKey(ent => ent.Id);
                ent.HasIndex(ent => ent.Value).IsUnique();
                ent.HasData(new Status() { Id = 1, Value = "Одобрена" });
                ent.HasData(new Status() { Id = 2, Value = "Отказ" });
                ent.HasData(new Status() { Id = 3, Value = "На проверке" });
            });

            modelBuilder.Entity<VisitingIndividual>(ent =>
            {
                ent.ToTable("VisitingIndividuals");
                ent.HasKey(ent => ent.VisitingIndividualId);
                ent.HasOne(ent => ent.Employee).WithMany();
            });

            modelBuilder.Entity<VisitingGroup>(ent =>
            {
                ent.ToTable("VisitingGroups");
                ent.HasKey(ent => ent.VisitingGroupId);
                ent.HasIndex(ent => ent.Name).IsUnique();
                ent.HasMany(ent => ent.Guests).WithMany();
            });

            modelBuilder.Entity<Departament>(ent =>
            {
                ent.ToTable("Departaments");
            });

            modelBuilder.Entity<Division>(ent =>
            {
                ent.ToTable("Divisions");
            });

            modelBuilder.Entity<BlackList>(ent =>
            {
                ent.ToTable("BlackLists");
                ent.HasKey(ent => ent.BlackListId);
            });

            modelBuilder.Entity<Job>(ent =>
            {
                ent.ToTable("Jobs");
                ent.HasKey(ent => ent.JobId);
                ent.HasIndex(ent => ent.Name).IsUnique();
            });

            modelBuilder.Entity<User>(ent =>
            {
                ent.ToTable("Users");
                ent.HasKey(ent => ent.UserId);
                ent.HasIndex(ent => ent.Login).IsUnique();
            });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=worm-atg.site;User=oleg2005;pwd=12345;database=wsr",ServerVersion.Parse("8.0.1"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
