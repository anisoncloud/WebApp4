using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.CategoryId, pc.ProductId });
            modelBuilder.Entity<Category>()
                .HasMany(c => c.ProductCategories)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
