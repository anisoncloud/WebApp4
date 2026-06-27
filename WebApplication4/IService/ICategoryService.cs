using WebApplication4.Dto;

namespace WebApplication4.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CategoryCreateDto dto);
        Task<bool> UpdateCategoryAsync(int id, CategoryUpdateDto dto);
    }
}
