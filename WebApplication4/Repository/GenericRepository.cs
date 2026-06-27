using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using WebApplication4.Data;
using WebApplication4.IRepository;
using WebApplication4.Models;

namespace WebApplication4.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }
            
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllFromDbAsync()
        {
            return await _dbSet.OrderByDescending(x => x.Id).ToListAsync();
        }

        public IQueryable<T?> GetById(int id)
        {
            return _dbSet.Where(x=>x.Id == id);
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<T> GetAllFromDb()
        {
            return _dbSet.OrderByDescending(x => x.Id);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
        }
    }
}
