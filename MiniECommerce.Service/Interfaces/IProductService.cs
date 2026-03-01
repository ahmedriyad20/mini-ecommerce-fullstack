

using MiniECommerce.Domain.Entities;

namespace MiniECommerce.Service.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        IQueryable<Product> GetAllProducts(int pageNumber, int pageSize);
        Task<Product> GetProductById(Guid productId);
        Task<bool> UpdateProduct(Product product);
    }
}
