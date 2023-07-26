using cesay.QR.API.Models;
using Microsoft.EntityFrameworkCore;

namespace cesay.QR.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Recipes and Restaurants
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Restaurant)
                .WithMany()
                .HasForeignKey(r => r.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict); // Set to restrict cascade delete

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany()
                .HasForeignKey(o => o.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict); // Set to restrict cascade delete

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany()
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductMaterial>()
                .HasOne(pm => pm.Restaurant)
                .WithMany()
                .HasForeignKey(pm => pm.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
            // Add other configurations as needed...

            base.OnModelCreating(modelBuilder);
        }
    }
}
