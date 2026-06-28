using WebApplication4.Data;
using WebApplication4.IRepository;
using WebApplication4.IService;
using WebApplication4.Models;
using WebApplication4.Repository;

namespace WebApplication4.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Category> Categories { get; }
        public IRepository<Product> Products { get; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Categories = new GenericRepository<Category>(context);
            Products = new GenericRepository<Product>(context);
        }       

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task RollBackDatabase()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
