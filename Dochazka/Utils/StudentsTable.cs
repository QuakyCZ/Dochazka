using System;
using System.IO;
using Dochazka.Utils.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Dochazka.Utils {
    public class StudentsTable:DbContext {
        private static string DBPATH =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dochazka/dochazka.db");
        
        public DbSet<StudentEntity> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            
        }
    }
}