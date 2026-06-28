using WebApplication4.Dto;

namespace WebApplication4.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllActiveProductAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllActiveProductWithCategoryAsync();
        Task<IEnumerable<ProductDto>> GetAllProductWithCategoryAsync();
        IQueryable<ProductDto> GetAllProduct();
        IQueryable<ProductDto> GetAllActiveProduct();
        Task<bool> AddProductAsync(ProductCreateDto dto);
        
    }
}
