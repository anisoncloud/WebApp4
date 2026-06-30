using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.DtoMapping
{
    public static class ProductMapping
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Categories = product.ProductCategories.Select(pc=>pc.Category.ToCategoryDto()).ToList()??new List<CategoryDto>()
            };
        }

        public static IEnumerable<ProductDto> ToProductDtoList(this IEnumerable<Product> products)
        {
            return products.Select(p => ToProductDto(p));
        }
    }
}
