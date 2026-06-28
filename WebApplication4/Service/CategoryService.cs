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

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _uow.Categories.GetAllFromDbAsync();
            return categories.ToCategoryListDto();
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _uow.Categories.GetByIdAsync(id);
            return category.ToCategoryDto();
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryUpdateDto dto)
        {
            var category = await _uow.Categories.GetByIdAsync(id);
            category.Name = dto.Name;
            category.Description = dto.Description;
            await _uow.Categories.UpdateAsync(category);
            await _uow.CommitAsync();
            return true;
        }

        public async Task<CategoryUpdateDto> GetCategoryForUpdate(int id)
        {
            var category = await _uow.Categories.GetByIdAsync(id);
            return category.ToCategoryUpdateDto();
        }
    }
}
