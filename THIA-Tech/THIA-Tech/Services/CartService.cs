using Microsoft.EntityFrameworkCore;
using System.Collections;
using THIA_Tech.Data;
using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _db;
        public CartService(ApplicationDbContext db) 
        {
            _db = db;
        }

        public async Task<CartItem> AddCartItem(int productId, string userId, int count)
        {
            var res = (await _db.CartItem.AddAsync(new CartItem { ProductId = productId, Count = count, UserId = userId })).Entity;
            _db.SaveChanges();

            return res;
        }

        public async Task RemoveCartItem(int id)
        {
            var cartitem = _db.CartItem.FirstOrDefault(p => p.Id == id);
            if(cartitem != null)
            {
                _db.Remove(cartitem);
            }
            _db.SaveChanges();

            return;
        }

        public async Task DeleteCart(IEnumerable<CartItem> items)
        {
            foreach (var item in items)
            {
                var cartitem = await _db.CartItem.FindAsync(item.Id);
                if (cartitem != null)
                {
                    _db.CartItem.Remove(cartitem);
                }
            }

            _db.SaveChanges();
            return;
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItems(string UserId)
        {
            return await _db.CartItem.Where(p => p.UserId == UserId).ToListAsync();
        }

        public async Task<CartItem> GetCartItemByIds(string userId, int productId)
        {
            return _db.CartItem.Where(p => p.UserId == userId &&  p.ProductId == productId).FirstOrDefault();
        }
    }
}
