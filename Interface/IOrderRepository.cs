using Customer_Order.Models;

namespace Customer_Order.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>?> GetAllOrders();
        Task<List<Order>?> GetOrderByDate(DateTime date);

        Task<List<Order>?> GetCustomerDetailByDate(DateTime date);
        Task<Order?> GetOrderById(Guid id);
        Task<float?> GetTotalOrder(DateTime date);

        Task<Order?> DeleteOrderById(Guid id);

        Task<Order?> CreateOrder(Order order);
        Task<Order?> UpdateOrderById(Guid id, Order order);
    }
}
