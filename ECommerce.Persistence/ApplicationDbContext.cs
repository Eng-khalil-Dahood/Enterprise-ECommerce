using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ECommerce.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // إدخال بيانات وهمية تلقائياً لتظهر في لوحة التحكم فوراً عند التشغيل
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop Dell XPS", Category = "Electronics", Price = 1200, Stock = 15 },
                new Product { Id = 2, Name = "iPhone 15 Pro", Category = "Electronics", Price = 1000, Stock = 25 },
                new Product { Id = 3, Name = "Running Shoes", Category = "Fashion", Price = 120, Stock = 50 },
                new Product { Id = 4, Name = "Coffee Maker", Category = "Home", Price = 85, Stock = 30 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerName = "Ahmad", TotalAmount = 1200, Status = "Completed", OrderDate = DateTime.UtcNow.AddDays(-2) },
                new Order { Id = 2, CustomerName = "Sami", TotalAmount = 1000, Status = "Completed", OrderDate = DateTime.UtcNow.AddDays(-1) },
                new Order { Id = 3, CustomerName = "Nour", TotalAmount = 205, Status = "Pending", OrderDate = DateTime.UtcNow }
            );
        }
    }
}