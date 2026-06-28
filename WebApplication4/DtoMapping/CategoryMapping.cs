using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.DtoMapping
{
    public static class CategoryMapping
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
        }
        public static IEnumerable<CategoryDto> ToCategoryListDto(this IEnumerable<Category> categories)
        {
            return categories.Select(category => category.ToCategoryDto());
        }

        public static Category ToCategory(this CategoryCreateDto dto)
        {
            return new()
            {
                Name = dto.Name,
                Description = dto.Description,
            };
        }
        public static CategoryUpdateDto ToCategoryUpdateDto(this Category dto)
        {
            return new()
            {
                
                Name = dto.Name,
                Description = dto.Description,
            };
        }
    }
}
