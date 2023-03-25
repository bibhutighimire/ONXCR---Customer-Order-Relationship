using Azure.Core;
using Customer_Order.Data;
using Customer_Order.Interface;
using Customer_Order.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Collections.Immutable;
using System.Linq;

namespace Customer_Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context= context;
        }
        public async Task<Order?> CreateOrder(Order order)
        {
            if(order.AmountOfOrder is null)
            {
                return null;
            }
            Customer c = new Customer();
            Order o = new Order();
            o.DateOfOrder= order.DateOfOrder;
            o.AmountOfOrder= order.AmountOfOrder;


           
            List<Order> listoforders = _context.Orders.ToList();
            List<Customer> listofcustomers = _context.Customers.ToList();
            var joined = (from or in listoforders
                         join cs in listofcustomers on or.CustomerId equals cs.Id
                         select or).ToList(); 
                  
            
            o.CustomerId = order.CustomerId;

            _context.Orders.Add(o);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> DeleteOrderById(Guid id)
        {
            var customer = await _context.Orders.FindAsync(id);
            if (customer == null)
            {
                return null;
            }
            _context.Orders.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Order>?> GetAllOrders()
        {
            List<Order> orders = await _context.Orders.ToListAsync();
            if(orders.Count == 0)
            {
                return null;
            }
            return orders;

        }

        public async Task<Order?> GetOrderById(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if(order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<Order?> UpdateOrderById(Guid id, Order order)
        {
            var updatedorder = await _context.Orders.FindAsync(id);
            if (updatedorder == null)
            {
                return null;
            }
            updatedorder.DateOfOrder = order.DateOfOrder;
            updatedorder.AmountOfOrder = order.AmountOfOrder;
            await _context.SaveChangesAsync();
            return updatedorder;
        }

        public async Task<List<Order>?> GetOrderByDate(DateTime date)
        {
            List<Order> order = await _context.Orders.Where(x=>x.DateOfOrder== date).ToListAsync();
            if (order == null)
            {
                return null;
            }
            
            return order;
        }

        public async Task<float?> GetTotalOrder(DateTime date)
        {
            float? orders = (float)Convert.ToDecimal(await _context.Orders.Where(x => x.DateOfOrder == date).SumAsync(y=>y.AmountOfOrder));
           
            if (orders.Value == 0)
            {
                return null;
            }

            return orders;
        }

        public async Task<List<Order>?> GetCustomerDetailByDate(DateTime date)
        {
            var join = await _context.Orders.Where(x => x.DateOfOrder == date).Include(x => x.Customer).ToListAsync();
            return join;
        }
    }
}
