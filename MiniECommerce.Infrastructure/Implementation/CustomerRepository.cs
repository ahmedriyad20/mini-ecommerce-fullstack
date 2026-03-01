

using MiniECommerce.Domain.Entities;
using MiniECommerce.Infrastructure.Context;
using MiniECommerce.Infrastructure.GenericBases;
using MiniECommerce.Infrastructure.Repositories;

namespace MiniECommerce.Infrastructure.Implementation
{
    public class CustomerRepository : GenericRepositoryAsync<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
