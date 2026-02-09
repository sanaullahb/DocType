using DocType.Models;
using Microsoft.EntityFrameworkCore;
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
            // EF Core now understands Id from Base<int> as PK
        }
        public DbSet<Profile> Profile { get; set; }
    }
}