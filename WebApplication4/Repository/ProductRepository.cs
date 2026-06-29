using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.IRepository;
using WebApplication4.Models;

namespace WebApplication4.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllActiveProductWithCategoriesAsync()
        {
            return await _dbSet
                .Where(x => x.IsDeleted == false)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category).
                ToListAsync();        
        }

        public async Task<IEnumerable<Product>> GetAllProductWithCategoriesAsync()
        {
            return await _dbSet
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .ToListAsync();
        }
    }
}
