using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Products.Queries
{
    public sealed record GetProductsQuery(int PageNumber = 1, int PageSize = 10)
    : IRequest<Result<PagedResult<ProductDto>>>;
}


