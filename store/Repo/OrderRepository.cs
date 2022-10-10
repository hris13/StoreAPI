using Microsoft.EntityFrameworkCore;
using store.Models;
using System.Security.Principal;

namespace store.Repo.Interfaces
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _ctx;
        public OrderRepository(StoreContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            _ctx.Orders.Add(order);
            await _ctx.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _ctx.Orders.ToListAsync();
        }
    }
}
