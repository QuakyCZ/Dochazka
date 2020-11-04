using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Dochazka.Utils.DatabaseEntities;
using System.Security.Permissions;

namespace Dochazka.Utils
{
    class StudentDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Assembly.GetExecutingAssembly().Location
            optionsBuilder.UseSqlite("Filename=dochazka.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEntity>().ToTable("Student");
            modelBuilder.Entity<StudentEntity>(entity =>
            {
                entity.HasKey(e => e.Name);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StudentEntity> Students { get; set; }
    }

    class PresenceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Assembly.GetExecutingAssembly().Location
            optionsBuilder.UseSqlite("Filename=dochazka.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PresenceEntity>().ToTable("Absence");
            modelBuilder.Entity<PresenceEntity>(entity =>
            {
                entity.HasKey(e => e.StudentID);
                entity.HasKey(e => e.Date);
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PresenceEntity> Presences { get; set; }
    }
}