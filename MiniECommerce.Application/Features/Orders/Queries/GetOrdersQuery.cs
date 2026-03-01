using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Orders.Queries
{
    public record GetOrdersQuery(int PageNumber = 1, int PageSize = 10)
    : IRequest<Result<PagedResult<OrderDto>>>;
}


