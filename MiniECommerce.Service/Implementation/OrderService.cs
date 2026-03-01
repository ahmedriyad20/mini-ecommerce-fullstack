

using MiniECommerce.Domain.Entities;
using MiniECommerce.Infrastructure.Repositories;
using MiniECommerce.Service.Interfaces;

namespace MiniECommerce.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderRepository.AddAsync(order);
        }

        public IQueryable<Order> GetAllOrders(int pageNumber, int pageSize)
        {
            return _orderRepository.GetAll();
        }

        public Task<Order> GetOrderById(Guid orderId)
        {
            var result = _orderRepository.GetByIdAsync(orderId);
            if(result == null)
                throw new KeyNotFoundException($"Order with id {orderId} not found");

            return result;
        }
    }
}
