using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public class OrderServiceDecorator : IOrderService
    {
        private readonly IOrderService Component;

        public Task<Order> CreateOrder(string address, IEnumerable<CartItem> items, string userId)
        {
            return Component.CreateOrder(address, items, userId);
        }

        public Task<IEnumerable<OrderItem>> CreateOrderItems(IEnumerable<CartItem> items, int orderId)
        {
            return Component.CreateOrderItems(items, orderId);
        }

        public Task<IEnumerable<Order>> GetAllOrders(string userId)
        {
            return Component.GetAllOrders(userId);
        }
        public void SendConfirmationEmail()
        {

        }
    }
}
