using BasketApp.Domain.Common;
using System.Linq.Expressions;

namespace BasketApp.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<bool> Update(Guid id, T entity);
        Task<bool> Delete(T entity);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeEntities);
        Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeEntities);
    }
}
