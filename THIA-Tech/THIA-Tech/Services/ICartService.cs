using System.Collections;
using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public interface ICartService
    {
        public Task<IEnumerable<CartItem>> GetAllCartItems(string UserId);
        public Task<CartItem> AddCartItem(int productId, string userId, int count);
        public Task DeleteCart(IEnumerable<CartItem> items);
        public Task<CartItem> GetCartItemByIds(string userId, int productId);
        public Task RemoveCartItem(int id);
    }
}
