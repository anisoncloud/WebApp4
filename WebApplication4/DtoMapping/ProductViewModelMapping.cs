using WebApplication4.Dto;
using WebApplication4.ViewModels;

namespace WebApplication4.DtoMapping
{
    public static class ProductViewModelMapping
    {
        public static ProductFormViewModel ToProductFormViewModel(this ProductDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                SelectedCategoryIds = dto.Categories.Select(c => c.Id).ToList()
            };
        }
    }
}
