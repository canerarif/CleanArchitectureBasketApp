using BasketApp.Application.Interfaces.Repository;
using BasketApp.Domain.Entities;
using BasketApp.Infrastructure.Context;

namespace BasketApp.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
