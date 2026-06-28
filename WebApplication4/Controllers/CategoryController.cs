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

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryForUpdate(id);
            return View(category);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _categoryService.UpdateCategoryAsync(id, dto);
            return RedirectToAction("Index");
        }

    }
}
