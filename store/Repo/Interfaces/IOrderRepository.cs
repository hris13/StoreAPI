using store.Models;

namespace store.Repo.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrderAsync(Order order);
        public Task<List<Order>> GetAllOrdersAsync();
    }
}
