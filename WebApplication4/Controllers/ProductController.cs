using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Dto;
using WebApplication4.DtoMapping;
using WebApplication4.IService;
using WebApplication4.ViewModels;

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
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllActiveProductAsync();
            return View(products);
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
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductFormViewModel vm)
        {
            var dto = vm.ToProductCreateDto();
            await _productService.AddProductAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _productService.GetActiveProductByIdWithCategories(id);
            if (dto==null)
            {
                return NotFound();
            }
            var vm = dto.ToProductFormViewModel();
            var categories = await _categoryService.GetAllCategoriesAsync();
            vm.CategoryOptions = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = vm.SelectedCategoryIds.Contains(id)
            }).ToList();
            return View(vm);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductFormViewModel vm)
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            vm.CategoryOptions = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = vm.SelectedCategoryIds.Contains(c.Id)
            }).ToList();
            var dto = vm.ToUpdateDto();
        }
    }
}
