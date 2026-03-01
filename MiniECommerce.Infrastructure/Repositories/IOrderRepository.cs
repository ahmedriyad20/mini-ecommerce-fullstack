

using MiniECommerce.Domain.Entities;
using MiniECommerce.Infrastructure.GenericBases;

namespace MiniECommerce.Infrastructure.Repositories
{
    public interface IOrderRepository : IGenericRepositoryAsync<Order>
    {
    }
}
