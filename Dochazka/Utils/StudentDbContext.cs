﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Windows.Forms;
using Dochazka.Utils.DatabaseEntities;

namespace Dochazka.Utils
{
    class StudentDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename="+Program.DBPATH, options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Presence>().ToTable("Presence");
            modelBuilder.Entity<Student>(entity => {
                entity.HasKey(e => e.Name);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Presence>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Presence>()
                .HasOne(s => s.Student)
                .WithMany(p => p.Presences);
            modelBuilder.Entity<Student>()
                .HasMany(p => p.Presences)
                .WithOne(s => s.Student);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Presence> Presences { get; set; }
    }
}