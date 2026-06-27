namespace WebApplication4.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
