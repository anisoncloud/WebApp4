using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Dto;
using WebApplication4.DtoMapping;
using WebApplication4.IService;

namespace WebApplication4.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var dto = new ProductDto();
            var vm = dto.ToProductFormViewModel();
            vm.CategoryOptions= categories.Select(c=>new SelectListItem
            {
                Value = c.Id.ToString(),
                Text=c.Name,
            }).ToList();
            return View(vm);
        }
    }
}
