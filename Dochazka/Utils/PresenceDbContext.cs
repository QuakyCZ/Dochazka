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
            modelBuilder.Entity<PresenceEntity>().ToTable("Presence");
            modelBuilder.Entity<PresenceEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.StudentId).IsRequired();
            });

            modelBuilder.Entity<PresenceEntity>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Presences)
                .HasForeignKey(p => p.StudentId)
                .HasPrincipalKey(s => s.Id);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PresenceEntity> Presences { get; set; }
    }
}