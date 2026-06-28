using WebApplication4.IRepository;
using WebApplication4.Models;

namespace WebApplication4.IService
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        Task<int> CommitAsync();
        Task RollBackDatabase();
    }
}
