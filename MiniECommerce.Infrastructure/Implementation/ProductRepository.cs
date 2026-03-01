

using MiniECommerce.Domain.Entities;
using MiniECommerce.Infrastructure.Context;
using MiniECommerce.Infrastructure.GenericBases;
using MiniECommerce.Infrastructure.Repositories;

namespace MiniECommerce.Infrastructure.Implementation
{
    public class ProductRepository : GenericRepositoryAsync<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
