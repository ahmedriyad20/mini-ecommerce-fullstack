namespace MiniECommerce.Shared.DTOs;

public record OrderDto(
    Guid Id,
    Guid CustomerId,
    DateTimeOffset OrderDate,
    List<OrderItemDto> Items,
    int TotalItems,
    decimal Subtotal,
    decimal DiscountPercentage,
    decimal DiscountAmount,
    decimal Total
);

public record OrderItemDto(
    Guid Id,
    Guid ProductId,
    string ProductName,
    int Quantity,
    decimal UnitPrice,
    decimal LineTotal
);

public record CreateOrderDto(
    Guid CustomerId,
    List<CreateOrderItemDto> Items
);

public record CreateOrderItemDto(
    Guid ProductId,
    int Quantity
);
