

using Customer_Order.Models;

namespace Customer_Order.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>?> GetAllCustomers();
        Task<Customer?> GetCustomerById(Guid id);

        Task<Customer?> DeleteCustomerById(Guid id);

        Task<Customer?> CreateCustomer(Customer customer);
        Task<Customer?> UpdateCustomerById(Guid id, Customer customer);




    }
}
