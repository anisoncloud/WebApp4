using WebApplication4.Models;

namespace WebApplication4.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllFromDbAsync();
        IQueryable<T> GetAllFromDb();
        Task<T?> GetByIdAsync(int id);
        IQueryable<T?> GetById(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);        
    }
}
