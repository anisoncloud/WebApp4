namespace WebApplication4.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public List<CategoryDto> Categories { get; set; } = new();
    }
}
