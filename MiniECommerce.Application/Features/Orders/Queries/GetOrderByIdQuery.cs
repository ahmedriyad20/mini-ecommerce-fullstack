using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Orders.Queries
{
    public record GetOrderByIdQuery(Guid Id) : IRequest<Result<OrderDto>>;
}


