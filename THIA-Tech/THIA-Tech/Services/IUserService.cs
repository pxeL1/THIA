using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public interface IUserService
    {
        public Task<User> GetUserByUsername(string username);
        public Task<User> GetUserByEmail(string email);
        public Task<Wishlist> AddItemToWishlist(int productId, string userId);
        public Task<IEnumerable<Product>> GetWishlist(string userId);
        public Task RemoveWishlistItem(int id);
        public Task<Wishlist> GetWishlistItemByIds(string userId, int productId);
    }
}
