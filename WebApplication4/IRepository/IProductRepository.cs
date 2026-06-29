using System.Data.SqlTypes;
using WebApplication4.Models;

namespace WebApplication4.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllActiveProductWithCategoriesAsync();
        Task<IEnumerable<Product>> GetAllProductWithCategoriesAsync();
    }
}
