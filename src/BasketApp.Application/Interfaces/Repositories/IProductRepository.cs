﻿using BasketApp.Application.Interfaces.Repositories;
using BasketApp.Domain.Entities;

namespace BasketApp.Application.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
