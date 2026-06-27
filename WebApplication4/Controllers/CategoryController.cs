using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dto;
using WebApplication4.IService;

namespace WebApplication4.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _categoryService.CreateCategoryAsync(dto);
            return RedirectToAction("Index");
            
        }
    }
}
