using System.Collections;
using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(string categoryName);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<string>> GetAllCategoryName();
    }
}
