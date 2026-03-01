namespace MiniECommerce.Shared.DTOs;

public record CustomerDto(
    Guid Id,
    string FullName,
    string Phone
);

public record CreateCustomerDto(
    string FullName,
    string Phone
);
