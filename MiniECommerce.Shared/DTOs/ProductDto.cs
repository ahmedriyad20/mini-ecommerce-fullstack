namespace MiniECommerce.Shared.DTOs;

public record ProductDto(
    Guid Id,
    string Name,
    decimal Price,
    int AvailableQuantity
);

public record CreateProductDto(
    string Name,
    decimal Price,
    int AvailableQuantity
);
