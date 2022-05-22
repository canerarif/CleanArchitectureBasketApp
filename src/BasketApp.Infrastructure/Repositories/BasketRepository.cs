using BasketApp.Application.Interfaces.Repository;
using BasketApp.Domain.Entities;
using BasketApp.Infrastructure.Context;

namespace BasketApp.Infrastructure.Repositories
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
