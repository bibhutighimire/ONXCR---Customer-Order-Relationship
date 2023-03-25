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

        //i. how much order was placed on “2023-01-02”
        //API Link: api/Orders/GetTotalOrderByDate/2023-01-02
        [HttpGet("GetTotalOrderByDate/{date}")]
        public async Task<IActionResult> GetTotalOrderByDate(DateTime date)
        {
           
            var order = await _orderRepository.GetTotalOrderByDate(date);


            if (order is null)
            {
                return NotFound("There was no order on this date");
            }
            return Ok(order);
        }

        //ii. From which countries the order was placed on “2023-01-02”
        //API Link: api/Orders/GetCustomerCountryByDate/2023-01-02
        [HttpGet("GetCustomerCountryByDate/{date}")]
        public async Task<IActionResult> GetCustomerCountryByDate(DateTime date)
        {
            var order = await _orderRepository.GetCustomerCountryByDate(date);


            if (order is null)
            {
                return NotFound("There was no order on this date");
            }
            return Ok(order);
        }

        //iii. Who ordered on “2023-01-02”
        //API Link: api/Orders/GetOrderNameByDate/2023-01-02

        [HttpGet("GetOrderNameByDate/{date}")]
        public async Task<IActionResult> GetOrderNameByDate(DateTime date)
        {
            var order = await _orderRepository.GetOrderNameByDate(date);
            if (order is null)
            {
                return NotFound("There was no order on this date");
            }
            return Ok(order);
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

      
        



    }
}
