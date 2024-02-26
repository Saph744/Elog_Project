using eLog.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eLog.Repository
{
    public class Repository<T> : IRepository<T> where T : Domain.Models.BaseEntity
    {
        private readonly eLogDBContext _context;
        private readonly DbSet<T> entities;
        public Repository(eLogDBContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await this.entities.ToListAsync();
        }
        public async Task<IList<T>> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await this.entities.AsNoTracking().Where(expression).ToListAsync();
         }
        public async Task InsertAsync(T entity)
        {
            if (entity == null)  
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
            entities.AsNoTracking();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
