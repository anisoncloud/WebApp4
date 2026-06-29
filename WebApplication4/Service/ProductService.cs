using WebApplication4.Dto;
using WebApplication4.DtoMapping;
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

        public async Task<bool> AddProductAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
            };
            foreach (var catId in dto.CategoryIds.Distinct())
            {
                product.ProductCategories.Add(new ProductCategory
                {
                    CategoryId = catId,
                    ProductId = product.Id
                });
            }
            await _uow.Products.AddAsync(product);
            await _uow.CommitAsync();
            return true;
        }

        public IQueryable<ProductDto> GetAllActiveProduct()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAllActiveProductAsync()
        {
            var products =  await _uow.Products.GetAllFromDbAsync();
            return products.ToProductDtoList();
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
