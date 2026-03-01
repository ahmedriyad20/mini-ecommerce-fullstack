using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Common;
using MiniECommerce.Application.Orders.Queries;
using MiniECommerce.Service.Interfaces;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Orders.Handlers;

public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, Result<PagedResult<OrderDto>>>
{
    private readonly IOrderService _orderService;

    public GetOrdersHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<Result<PagedResult<OrderDto>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var query = _orderService.GetAllOrders(1, int.MaxValue)
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product);

        var totalCount = await query.CountAsync();

        var orders = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        var orderDtos = orders.Select(order => new OrderDto(
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
        )).ToList();

        var result = new PagedResult<OrderDto>
        {
            Items = orderDtos,
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };

        return Result<PagedResult<OrderDto>>.Success(result);
    }
}
