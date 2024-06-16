using Microsoft.AspNetCore.Mvc;
using THIA_Tech.Data;
using THIA_Tech.Services;

namespace THIA_Tech.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICategoryService _categoryService;


        public CategoryController(ApplicationDbContext db, ICategoryService categoryService)
        {
            _db = db;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string categoryName)
        {
            if (categoryName != null)
            {
                await _categoryService.CreateAsync(categoryName);
            }

            return RedirectToAction("Index");
        }
    }
}
