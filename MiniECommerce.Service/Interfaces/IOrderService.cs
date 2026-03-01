
using MiniECommerce.Domain.Entities;

namespace MiniECommerce.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        IQueryable<Order> GetAllOrders(int pageNumber, int pageSize);
        Task<Order> GetOrderById(Guid orderId);
    }
}
