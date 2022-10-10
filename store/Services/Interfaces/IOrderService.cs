using storeDTO.Account;
using storeDTO.Address;

namespace store.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDTO> CreateOrderAsync(OrderDTO order);

        public Task<List<OrderDTO>> GetAllAsync();
    }
}
