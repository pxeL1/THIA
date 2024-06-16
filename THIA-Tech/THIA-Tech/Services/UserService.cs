using Microsoft.EntityFrameworkCore;
using THIA_Tech.Data;
using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.User.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _db.User.FirstOrDefaultAsync(c => c.UserName == username);
        }
      
        public async Task<Wishlist> AddItemToWishlist(int productId, string userId)
        {
            var res = (await _db.Wishlist.AddAsync(new Wishlist { ProductId = productId, UserId = userId })).Entity;
            _db.SaveChanges();

            return res;
        }
        public async Task<IEnumerable<Product>> GetWishlist(string userId)
        {
            var wishlist = _db.Wishlist.Where(p => p.UserId == userId).ToListAsync().Result;
            var products = new List<Product>();
            foreach(var wish in wishlist) 
            {
                products.Add(_db.Product.FirstOrDefault(p => p.Id == wish.ProductId));
            }
            return products;
        }
        public async Task RemoveWishlistItem(int id)
        {
            var cartitem = _db.Wishlist.FirstOrDefault(p => p.Id == id);
            if (cartitem != null)
            {
                _db.Remove(cartitem);
            }
            _db.SaveChanges();

            return;
        }
        public async Task<Wishlist> GetWishlistItemByIds(string userId, int productId)
        {
            
            return _db.Wishlist.Where(p => p.UserId == userId && p.ProductId == productId).FirstOrDefault();
        }
    }
}
