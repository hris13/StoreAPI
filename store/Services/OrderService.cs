using AutoMapper;
using store.Models;
using store.Repo;
using store.Repo.Interfaces;
using store.Services.Interfaces;
using storeDTO.Account;
using storeDTO.Address;
using storeDTO.order;
using System.Collections.Generic;
using System.Net;

namespace store.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrdDTO> CreateOrderAsync(OrdDTO order)
        {
            if (order != null)
            {
                Order newOrder = _mapper.Map<Order>(order);
                await _orderRepository.AddOrderAsync(newOrder);
                return order;
            }
            else return null;
        }

        public async Task<List<OrderDTO>> GetAllAsync()
        {
            
            List<Order> alist = await _orderRepository.GetAllOrdersAsync();
            List<OrderDTO> list = _mapper.Map<List<OrderDTO>>(alist);

            return list;
        }
    }
}
