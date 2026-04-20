using Microsoft.EntityFrameworkCore;
using PAA_LKM_01.Models;

namespace PAA_LKM_01.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Index untuk performa
            modelBuilder.Entity<Camera>()
                .HasIndex(c => c.Brand)
                .HasDatabaseName("idx_cameras_brand");

            modelBuilder.Entity<Camera>()
                .HasIndex(c => c.PricePerDay)
                .HasDatabaseName("idx_cameras_price");

            modelBuilder.Entity<Rental>()
                .HasIndex(r => r.Status)
                .HasDatabaseName("idx_rentals_status");

            modelBuilder.Entity<Rental>()
                .HasIndex(r => r.RentalDate)
                .HasDatabaseName("idx_rentals_date");
        }
    }
}