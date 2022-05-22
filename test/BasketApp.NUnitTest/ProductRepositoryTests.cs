using BasketApp.Domain.Entities;
using BasketApp.Infrastructure.Context;
using BasketApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace BasketApp.NUnitTest
{
    public class ProductRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> contextOptions;

        [SetUp]
        public void AddDbContext()
        {
            var dbName = $"ProductsDb_{DateTime.Now.ToFileTimeUtc()}";
            contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        private async Task<ProductRepository> CreateRepositoryAsync()
        {
            ApplicationDbContext context = new ApplicationDbContext(contextOptions);
            await PopulateDataAsync(context);
            return new ProductRepository(context);
        }

        private async Task PopulateDataAsync(ApplicationDbContext context)
        {
            int index = 1;

            while (index <= 3)
            {
                var product = new Product();
                if (index == 1)
                {
                    product = new Product()
                    {
                        Id = new Guid("f6dae779-396c-4627-8902-009a02eb8053"),
                        CreateDate = DateTime.UtcNow,
                        ProductName = "Product" + index,
                        Stock = index
                    };
                }
                else
                {
                    product = new Product()
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.UtcNow,
                        ProductName = "Product" + index,
                        Stock = index
                    };
                }
                index++;
                await context.Products.AddAsync(product);
            }

            await context.SaveChangesAsync();
        }

        [Test]
        public async Task GetByIdAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            var product = await repository.GetByIdAsync(x => x.Id == new Guid("f6dae779-396c-4627-8902-009a02eb8053"));

            Assert.NotNull(product);
            Assert.AreEqual("Product1", product.ProductName);
        }

        [Test]
        public async Task Update_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            var product = await repository.GetByIdAsync(x => x.Id == new Guid("f6dae779-396c-4627-8902-009a02eb8053"));

            product.Stock = 100;

            var isUpdated = await repository.Update(product.Id, product);

            Assert.AreEqual(true, isUpdated);
        }
    }
}