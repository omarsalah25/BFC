using CarRentalPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPortfolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<HeroImage> HeroImages { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // We do NOT use HasData here to avoid the "Reset" issue.
        }
    }
}