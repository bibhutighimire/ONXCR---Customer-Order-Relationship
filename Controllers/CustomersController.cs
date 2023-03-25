using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Customer_Order.Data;
using Customer_Order.Models;
using Customer_Order.Interface;

namespace Customer_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository= customerRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>?>> GetCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer?>> GetCustomer(Guid id)
        {
            return await _customerRepository.GetCustomerById(id);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, Customer customer)
        {
            var updatedcustomer = await _customerRepository.UpdateCustomerById(id, customer);
            if(updatedcustomer == null)
            {
                return BadRequest("fdsfds");
            }
            return Ok(updatedcustomer);
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer?>> PostCustomer(Customer customer)
        {
            return await _customerRepository.CreateCustomer(customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult?> DeleteCustomerById(Guid id)
        {
            var customer =  await _customerRepository.DeleteCustomerById(id);
            if(customer is null)
            {
                return NotFound();
            }
            return Ok(customer); 

        }

       
    }
}
