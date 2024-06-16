using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using THIA_Tech.Data;
using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public OrderService(ApplicationDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<Order> CreateOrder(string address, IEnumerable<CartItem> items, string userId)
        {
            var res = (await _db.Order.AddAsync(new Order { Address = address, Items = items, OrderDate = DateTime.Now, UserId = userId })).Entity;
            _db.SaveChanges();

            return res;
        }

        public async Task<IEnumerable<OrderItem>> CreateOrderItems(IEnumerable<CartItem> items, int orderId)
        {
            foreach (var item in items)
            {
                await _db.OrderItem.AddAsync(new OrderItem { Count = item.Count, OrderId = orderId, ProductId = item.ProductId });
            }
            _db.SaveChanges();

            return await _db.OrderItem.Where(p => p.OrderId == orderId).ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetAllOrders(string userId)
        {
            return await _db.Order.Where(p => p.UserId == userId).ToListAsync();
        }
    }
}
