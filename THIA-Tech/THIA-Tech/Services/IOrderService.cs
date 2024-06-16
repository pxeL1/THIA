using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public interface IOrderService
    {
        public Task<Order> CreateOrder(string address, IEnumerable<CartItem> items, string userId);
        public Task<IEnumerable<OrderItem>> CreateOrderItems(IEnumerable<CartItem> items, int orderId);
        public Task<IEnumerable<Order>> GetAllOrders(string userId);
    }
}
