using DocType.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Xml.Linq;

namespace DocType.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doc>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DocTimeSlot>()
                .HasIndex(s => new { s.DoctorId, s.Date, s.Time })
                .IsUnique();
        }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Doc> Doc { get; set; }
        public DbSet<DocTimeSlot> DocTimeSlot { get; set; } 
        public DbSet<DocAvailability> DocAvailabilities { get; set; }
    }
}