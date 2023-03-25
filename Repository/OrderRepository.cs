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
            _context = context;
        }

        //i. how much order was placed on “2023-01-02”
        //API Link: api/Orders/GetTotalOrderByDate/2023-01-02

        public async Task<float?> GetTotalOrderByDate(DateTime date)
        {
            //LINQ query below connects woth Orders table and using where() clause it filters rows and gets data whose date of order was passed in parameter. Then using SumAsync() it sums the AmountOfOrder of all the rows. This is asynchronous call. The sum of AmountOfOrder is stored in orders and checked for null reference error and returned.

            float? orders = (float)Convert.ToDecimal(await _context.Orders.Where(x => x.DateOfOrder == date).SumAsync(y => y.AmountOfOrder));

            if (orders.Value == 0)
            {
                return null;
            }

            return orders;
        }
        //ii. From which countries the order was placed on “2023-01-02”
        //API Link: api/Orders/GetCustomerCountryByDate/2023-01-02
        public async Task<List<string?>?> GetCustomerCountryByDate(DateTime date)
        {
            //LINQ query below connects woth Orders table and using where() clause it filters rows and gets data whose date of order was passed in parameter. Then using Include() it does quick eager loading to get data from Customer table whose Id is equal to CustomerId in Order table. Finally using Select() it gets data of only the Country column. Since this is asynchronous call, it's using ToListAsync() to list the data and store in List of string.

            List<string?>? orders = await _context.Orders.Where(x => x.DateOfOrder == date).Include(z => z.Customer).Select(s => s.Customer!.Country).ToListAsync();
            if (orders == null)
            {
                return null;
            }
            return orders;
        }

        //iii. Who ordered on “2023-01-02”
        //API Link: api/Orders/GetOrderNameByDate/2023-01-02

        public async Task<List<string?>?> GetOrderNameByDate(DateTime date)
        {
            //LINQ query below connects woth Orders table and using where() clause it filters rows and gets data whose date od order was passed in parameter. Then using Include() it does quick eager loading to get data from Customer table whose Id is equal to CustomerId in Order table. Finally using Select() it gets data of only the Name column. Since this is asynchronous call, it's using ToListAsync() to list the data and store in List of string.
            List<string?>? orders = await _context.Orders.Where(x => x.DateOfOrder == date).Include(z => z.Customer).Select(s => s.Customer!.Name).ToListAsync();
            if (orders == null)
            {
                return null;
            }
            return orders;

        }

        public async Task<Order?> CreateOrder(Order order)
        {
            if (order.AmountOfOrder is null)
            {
                return null;
            }
            Order o = new Order();
            o.DateOfOrder = order.DateOfOrder;
            o.AmountOfOrder = order.AmountOfOrder;
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
            if (orders.Count == 0)
            {
                return null;
            }
            return orders;

        }

        public async Task<Order?> GetOrderById(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
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
    }
}
