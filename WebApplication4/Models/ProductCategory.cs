namespace WebApplication4.Models
{
    public class ProductCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();        
        public int ProductId { get; set; }
        public Product Product { get; set; } = new();
    }
}
