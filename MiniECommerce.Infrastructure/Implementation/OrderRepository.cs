
using MiniECommerce.Domain.Entities;
using MiniECommerce.Infrastructure.Context;
using MiniECommerce.Infrastructure.GenericBases;
using MiniECommerce.Infrastructure.Repositories;

namespace MiniECommerce.Infrastructure.Implementation
{
    public class OrderRepository : GenericRepositoryAsync<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
