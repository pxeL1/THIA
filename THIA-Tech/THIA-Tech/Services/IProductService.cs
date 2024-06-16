using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> SearchProducts(string searchQuery);
        public Task<IEnumerable<Product>> GetLatestProducts();
        public Task<IEnumerable<Product>> GetProductsByCategory(string category);
        public Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
        public Task<Product> GetProductById(int productId);
        public Task<IEnumerable<Product>> GetProductsInCart(IEnumerable<CartItem> items);
        public Task<string> GetProductImage(int id);
        public Task<Product> AddProduct(Product product);
    }
}
