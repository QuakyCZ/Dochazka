using System;
using System.Data.Entity.Migrations;
using System.IO;
using Dochazka.Utils.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Dochazka.Utils {
    public class StudentsTable:DbContext {
        private static string DBPATH =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dochazka\\dochazka.db");
        
        public DbSet<StudentEntity> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=" + DBPATH);
            Console.WriteLine("Data Source="+DBPATH);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<StudentEntity>().HasKey(s => s.Id);
        }
    }
}