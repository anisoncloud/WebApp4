using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication4.ViewModels
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public List<int> SelectedCategoryIds { get; set; } = new();
        public List<SelectListItem> CategoryOptions { get; set; } = new();
    }
}
