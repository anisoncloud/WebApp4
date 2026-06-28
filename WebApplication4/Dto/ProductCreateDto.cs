namespace WebApplication4.Dto
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public List<int> CategoryIds { get; set; } = new();

    }
}
