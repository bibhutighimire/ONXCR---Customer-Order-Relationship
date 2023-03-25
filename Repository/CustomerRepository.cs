using Customer_Order.Data;
using Customer_Order.Interface;
using Customer_Order.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer_Order.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer?> CreateCustomer(Customer customer)
        {
            if(customer is null)
            {
                return null;
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
            
        }

        public async Task<Customer?> DeleteCustomerById(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
            {
                return null;
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>?> GetAllCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            if(customers is null)
            {
                return null;
            }
            return customers;
        }

        public async Task<Customer?> GetCustomerById(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if(customer is null)
            {
                return null;
            }
            return customer;
            
        }

        public async Task<Customer?> UpdateCustomerById(Guid id,Customer customer)
        {
            var updatedcustomer = await _context.Customers.FindAsync(id);
            if (updatedcustomer is null)
            {
                return null;
            }
            updatedcustomer.Name = customer.Name;
            updatedcustomer.Country = customer.Country;
            await _context.SaveChangesAsync();
            return updatedcustomer;
        }
    }
}
