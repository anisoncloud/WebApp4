using WebApplication4.Dto;
using WebApplication4.DtoMapping;
using WebApplication4.IService;

namespace WebApplication4.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CreateCategoryAsync(CategoryCreateDto dto)
        {
            var category = dto.ToCategory();
            await _uow.Categories.AddAsync(category);
            await _uow.CommitAsync();
        }

        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(int id, CategoryUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
