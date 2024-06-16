using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

using THIA_Tech.Data;
using THIA_Tech.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace THIA_Tech.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Product>> SearchProducts(string searchQuery)
        {
            return await _db.Product.Where(p => (p.Manufacturer + p.Model + p.Category.Name).ToUpper().Contains(searchQuery.ToUpper())).ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetLatestProducts()
        {
            return await _db.Product.OrderByDescending(p => p.Id).Take(21).ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            return await _db.Product.Where(p => p.Category.Name == category).ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
           return await _db.Product.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetProductsInCart(IEnumerable<CartItem> items)
        {
            List<Product> products = new List<Product>();
            foreach(CartItem item in items)
            {
                products.Add(await _db.Product.FirstOrDefaultAsync(p => p.Id == item.ProductId));
            }
            return products;
        }
        public async Task<string> GetProductImage(int id)
        {
            var content = _db.ProductImage.Where(p => p.ProductId == id).FirstOrDefault().Content;
            return _db.ProductImage.Where(p => p.ProductId == id).FirstOrDefault().Content;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var res = _db.Product.Add(product).Entity;
            _db.SaveChanges();

            return res;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _db.Product.Where(p => p.Category.Id == categoryId).ToListAsync();
        }
    }
}
