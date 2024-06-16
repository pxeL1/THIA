using Microsoft.AspNetCore.Mvc;
using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public class ProtectionProxy : IProductService
    {
        private readonly ProductService Subject;

        public Task<IEnumerable<Product>> GetLatestProducts()
        {
            return ((IProductService)Subject).GetLatestProducts();
        }

        public Task<Product> GetProductById(int productId)
        {
            return ((IProductService)Subject).GetProductById(productId);
        }

        public Task<string> GetProductImage(int id)
        {
            return ((IProductService)Subject).GetProductImage(id);
        }

        public Task<IEnumerable<Product>> GetProductsByCategory(string categoryId)
        {
            return ((IProductService)Subject).GetProductsByCategory(categoryId);
        }

        public Task<IEnumerable<Product>> GetProductsInCart(IEnumerable<CartItem> items)
        {
            return ((IProductService)Subject).GetProductsInCart(items);
        }

        public Task<IEnumerable<Product>> SearchProducts(string searchQuery)
        {
            return ((IProductService)Subject).SearchProducts(searchQuery);
        }
        public bool ValidateProduct(Product product)
        {
            return true;
        }
        public Task<Product> AddProduct(Product product)
        {
            if(ValidateProduct(product))
            {
                return ((IProductService)Subject).AddProduct(product);
            }
            return default;
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return ((IProductService)Subject).GetProductsByCategoryId(categoryId);
        }
    }
}
