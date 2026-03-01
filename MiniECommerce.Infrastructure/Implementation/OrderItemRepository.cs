

using MiniECommerce.Domain.Entities;
using MiniECommerce.Infrastructure.Context;
using MiniECommerce.Infrastructure.GenericBases;
using MiniECommerce.Infrastructure.Repositories;

namespace MiniECommerce.Infrastructure.Implementation
{
    public class OrderItemRepository : GenericRepositoryAsync<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
