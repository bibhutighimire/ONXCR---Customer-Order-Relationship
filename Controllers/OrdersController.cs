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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository= orderRepository;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>?>> GetOrders()
        {
            return await _orderRepository.GetAllOrders();

        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order?>> GetOrder(Guid id)
        {
          return await _orderRepository.GetOrderById(id);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(Guid id, Order order)
        {
            var updateorder = await _orderRepository.UpdateOrderById(id, order);
            if (updateorder is null)
            {
                return NotFound();
            }
            return Ok(updateorder);
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order?>> PostOrder(Order order)
        {
         return await _orderRepository.CreateOrder(order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var order = await _orderRepository.DeleteOrderById(id);
            if(order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("GetOrderByDate/{date}")]
        public async Task<IActionResult> GetOrderByDate(DateTime date)
        {
            var order = await _orderRepository.GetOrderByDate(date);
            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("GetCustomerDetailByDate/{date}")]
        public async Task<IActionResult> GetCustomerDetailByDate(DateTime date)
        {
            var order = await _orderRepository.GetCustomerDetailByDate(date);


            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("GetTotalOrderByDate/{date}")]
        public async Task<IActionResult> GetTotalOrder(DateTime date)
        {
            var order = await _orderRepository.GetTotalOrder(date);


            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }



    }
}
