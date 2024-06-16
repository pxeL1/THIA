using Microsoft.EntityFrameworkCore;
using System.Collections;
using THIA_Tech.Data;
using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db) 
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _db.Category.ToListAsync();
        }
  
        public async Task<Category> CreateAsync(string categoryName)
        {
            var res = (await _db.Category.AddAsync(new Category { Name = categoryName })).Entity;

            await _db.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<string>> GetAllCategoryName()
        {
            return await _db.Category.Select(p => p.Name).ToListAsync();
        }
    }
}
