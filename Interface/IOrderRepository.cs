using Customer_Order.Models;
using static NuGet.Packaging.PackagingConstants;

namespace Customer_Order.Interface
{
    public interface IOrderRepository
    {
        //i. how much order was placed on “2023-01-02”
        //API Link: api/Orders/GetTotalOrderByDate/2023-01-02
        Task<float?> GetTotalOrderByDate(DateTime date);

        //ii. From which countries the order was placed on “2023-01-02”
        //API Link: api/Orders/GetCustomerCountryByDate/2023-01-02
        Task<List<string?>?> GetCustomerCountryByDate(DateTime date);

        //iii. Who ordered on “2023-01-02”
        //API Link: api/Orders/GetOrderNameByDate/2023-01-02
        Task<List<string?>?> GetOrderNameByDate(DateTime date);
        Task<List<Order>?> GetAllOrders();
        Task<Order?> GetOrderById(Guid id);
        Task<Order?> DeleteOrderById(Guid id);
        Task<Order?> CreateOrder(Order order);
        Task<Order?> UpdateOrderById(Guid id, Order order);
    }
}
