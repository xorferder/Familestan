using System.Linq.Expressions;

namespace Familestan.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(long id);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
