
using MiniECommerce.Domain.Entities;

namespace MiniECommerce.Service.Interfaces
{
    public interface IOrederItemService
    {
        Task<OrderItem> CreateOrderItem(OrderItem orderItem);
        IQueryable<OrderItem> GetAllOrderItems(int pageNumber, int pageSize);
        Task<OrderItem> GetOrderItemById(Guid orderItemId);
    }
}
