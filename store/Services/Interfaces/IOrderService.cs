using store.Models;
using storeDTO.Account;
using storeDTO.order;

namespace store.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<OrdDTO> CreateOrderAsync(OrdDTO order);

        public Task<List<OrderDTO>> GetAllAsync();
    }
}
