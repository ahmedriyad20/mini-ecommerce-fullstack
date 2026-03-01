

using MiniECommerce.Domain.Entities;
using MiniECommerce.Infrastructure.Repositories;
using MiniECommerce.Service.Interfaces;

namespace MiniECommerce.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public IQueryable<Product> GetAllProducts(int pageNumber, int pageSize)
        {
            return _productRepository.GetAll();
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            var result  = await _productRepository.GetByIdAsync(productId);
            if(result == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found");

            return result;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var result = await _productRepository.UpdateAsync(product);
            return result != null;
        }
    }
}
