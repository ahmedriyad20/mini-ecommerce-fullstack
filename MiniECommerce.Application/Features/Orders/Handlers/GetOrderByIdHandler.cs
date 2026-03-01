using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Common;
using MiniECommerce.Application.Orders.Queries;
using MiniECommerce.Service.Interfaces;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Orders.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderDto>>
    {
        private readonly IOrderService _orderService;

        public GetOrderByIdHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetAllOrders(1, int.MaxValue)
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == request.Id);

            if (order is null)
            {
                return Result<OrderDto>.Failure($"Order with ID {request.Id} not found");
            }

            var orderDto = new OrderDto(
                order.Id,
                order.CustomerId,
                order.OrderDate,
                order.OrderItems.Select(oi => new OrderItemDto(
                    oi.Id,
                    oi.ProductId,
                    oi.Product.Name,
                    oi.Quantity,
                    oi.UnitPrice,
                    oi.LineTotal
                )).ToList(),
                order.TotalItems,
                order.Subtotal,
                order.DiscountPercentage,
                order.DiscountAmount,
                order.Total
            );

            return Result<OrderDto>.Success(orderDto);
        }
    }
}
