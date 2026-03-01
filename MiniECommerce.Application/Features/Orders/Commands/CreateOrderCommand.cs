using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Orders.Commands
{
    public sealed record CreateOrderCommand(Guid CustomerId, List<CreateOrderItemDto> Items)
    : IRequest<Result<OrderDto>>;
}


