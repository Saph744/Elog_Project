using eLog.Domain.Models;
using System.Linq.Expressions;

namespace eLog.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task InsertAsync(T entity);
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetByIdAsync(Expression<Func<T, bool>> expression);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
