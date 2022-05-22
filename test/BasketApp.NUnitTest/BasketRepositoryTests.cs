using BasketApp.Domain.Entities;
using BasketApp.Infrastructure.Context;
using BasketApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace BasketApp.NUnitTest
{
    public class BasketRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> contextOptions;

        [SetUp]
        public void AddDbContext()
        {
            var dbName = $"BasketsDb_{DateTime.Now.ToFileTimeUtc()}";
            contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        private async Task<BasketRepository> CreateRepositoryAsync()
        {
            ApplicationDbContext context = new ApplicationDbContext(contextOptions);
            await PopulateDataAsync(context);
            return new BasketRepository(context);
        }

        private async Task PopulateDataAsync(ApplicationDbContext context)
        {
            int index = 1;

            while (index <= 3)
            {
                var basket = new Basket();
                if (index == 1)
                {
                    basket = new Basket()
                    {
                        Id = Guid.NewGuid(),
                        ProductCount = 5,
                        ProductId = new Guid("30fc7d2f-daf0-4b96-b8a1-c32f3e37ba51"),
                        CreateDate = DateTime.UtcNow
                    };
                }
                else
                {
                    basket = new Basket()
                    {
                        Id = Guid.NewGuid(),
                        ProductCount = 8,
                        ProductId = Guid.NewGuid(),
                        CreateDate = DateTime.UtcNow
                    };
                }
                index++;
                await context.Basket.AddAsync(basket);
            }

            await context.SaveChangesAsync();
        }

        [Test]
        public async Task GetAllListAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            var basketList = await repository.GetAllListAsync();

            Assert.AreEqual(3, basketList.Count);
        }

        [Test]
        public async Task GetByIdAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            var basket = await repository.GetByIdAsync(x => x.ProductId == new Guid("30fc7d2f-daf0-4b96-b8a1-c32f3e37ba51"));

            Assert.NotNull(basket);
            Assert.AreEqual(5, basket.ProductCount);
        }

        [Test]
        public async Task AddAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            await repository.AddAsync(new Basket()
            {
                CreateDate = DateTime.UtcNow,
                ProductCount = 5,
                ProductId = new Guid()
            });

            var basketList = await repository.GetAllListAsync();
            Assert.AreEqual(4, basketList.Count);
        }

        [Test]
        public async Task Delete_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            var basket = await repository.GetByIdAsync(x => x.ProductId == new Guid("30fc7d2f-daf0-4b96-b8a1-c32f3e37ba51"));

            await repository.Delete(basket);

            var basketList = await repository.GetAllListAsync();
            Assert.AreEqual(2, basketList.Count);
        }

        [Test]
        public async Task Update_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            var basket = await repository.GetByIdAsync(x => x.ProductId == new Guid("30fc7d2f-daf0-4b96-b8a1-c32f3e37ba51"));

            basket.ProductCount = 20;

            var isUpdated = await repository.Update(basket.Id, basket);

            Assert.AreEqual(true, isUpdated);
        }
    }
}