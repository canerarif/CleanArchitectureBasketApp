using BasketApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasketApp.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Basket { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>().HasOne(b => b.Product).WithMany().HasForeignKey(b => b.ProductId);

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = new Guid("fbc178bf-6751-48bb-8df3-5dfbf00194ec"), ProductName = "Pencil", Stock = 20 },
                new Product() { Id = new Guid("5c95c5d4-c887-493d-9589-0efc9f20e67e"), ProductName = "Paper A4", Stock = 10 },
                new Product() { Id = new Guid("f27e09f4-7a24-4890-a595-a02827a98aa4"), ProductName = "Book", Stock = 100 }
                );

            modelBuilder.Entity<Basket>().HasData(
                new Basket() { Id = Guid.NewGuid(), ProductCount = 2, ProductId = new Guid("fbc178bf-6751-48bb-8df3-5dfbf00194ec") },
                new Basket() { Id = Guid.NewGuid(), ProductCount = 4, ProductId = new Guid("5c95c5d4-c887-493d-9589-0efc9f20e67e") },
                new Basket() { Id = Guid.NewGuid(), ProductCount = 7, ProductId = new Guid("f27e09f4-7a24-4890-a595-a02827a98aa4") }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
