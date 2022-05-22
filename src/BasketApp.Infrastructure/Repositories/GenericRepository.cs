using BasketApp.Application.Interfaces.Repositories;
using BasketApp.Domain.Common;
using BasketApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BasketApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Update(Guid id, T entity)
        {
            var updatingEntity = dbContext.Set<T>().Find(id);
            if (updatingEntity != null)
            {
                dbContext.Entry(updatingEntity).CurrentValues.SetValues(entity);
                var modifiedRows = await dbContext.SaveChangesAsync();

                return modifiedRows > 0;
            }
            return false;
        }

        public async Task<bool> Delete(T entity)
        {
            var deletedEntity = dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            var deletedRows = await dbContext.SaveChangesAsync();

            return deletedRows > 0;
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeEntities)
        {
            var result = dbContext.Set<T>().AsQueryable();
            if (includeEntities.Length > 0)
                result = result.AsNoTracking<T>().IncludeMultiple(includeEntities);

            var item = await result.SingleOrDefaultAsync(filter);

            return item;
        }

        public async Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeEntities)
        {
            var result = filter == null
                        ? dbContext.Set<T>().AsQueryable()
                        : dbContext.Set<T>().Where(filter).AsQueryable();

            if (includeEntities.Length > 0)
                result = result.AsNoTracking<T>().IncludeMultiple(includeEntities);

            var list = await result.ToListAsync();

            return list;
        }
    }

    public static class LinqHelper
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
