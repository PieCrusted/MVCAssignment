using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository {
    public class BaseRepository<T> : IBaseRepository<T> where T : class {
        protected readonly DbContext _dbContext;
        public BaseRepository(DbContext dbContext) {
            _dbContext = dbContext;
        }
        public virtual async Task<T> GetByIdAsync(int id) {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync() {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<int> AddAsync(T entity) {
            _dbContext.Set<T>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<int> UpdateAsync(T entity) {
            _dbContext.Set<T>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<int> DeleteAsync(int id) {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null) return 0;
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}