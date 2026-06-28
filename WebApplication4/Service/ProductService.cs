using WebApplication4.Dto;
using WebApplication4.IService;
using WebApplication4.Models;

namespace WebApplication4.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<ProductDto> AddProductAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                ProductCategories = 
            }
        }

        public IQueryable<ProductDto> GetAllActiveProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllActiveProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllActiveProductWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductDto> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllProductWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
