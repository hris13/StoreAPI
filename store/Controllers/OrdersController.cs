using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;
using store.Services.Interfaces;
using storeDTO.Address;

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService=orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetOrders()
        {
            return await _orderService.GetAllAsync();
        }

        // GET: api/Orders/5
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO order)
        {
             await _orderService.CreateOrderAsync(order);


            return order;
        }
     
    }
}
