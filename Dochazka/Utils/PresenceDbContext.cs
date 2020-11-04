using System.Reflection;
using Dochazka.Utils.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Dochazka.Utils {
    public class PresenceDbContext:DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Assembly.GetExecutingAssembly().Location
            optionsBuilder.UseSqlite("Filename="+Program.DBPATH, options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Presence>().ToTable("Presence");
            modelBuilder.Entity<Presence>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.StudentId);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Presence>()
                .HasOne(p=>p.Student)
                .WithMany(s => s.Presences)
                .HasForeignKey(p => p.StudentId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Presence> Presences { get; set; }
    }
}