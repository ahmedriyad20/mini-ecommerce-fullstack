using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Common;
using MiniECommerce.Application.Products.Queries;
using MiniECommerce.Service.Interfaces;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Products.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, Result<PagedResult<ProductDto>>>
    {
        private readonly IProductService _productService;

        public GetProductsHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result<PagedResult<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _productService.GetAllProducts(1, int.MaxValue);

            var totalCount = await query.CountAsync();

            var products = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new ProductDto(
                    p.Id,
                    p.Name,
                    p.Price,
                    p.AvailableQuantity
                ))
                .ToListAsync();

            var result = new PagedResult<ProductDto>
            {
                Items = products,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            return Result<PagedResult<ProductDto>>.Success(result);
        }
    }
}
