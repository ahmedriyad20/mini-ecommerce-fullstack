using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Products.Commands
{
    public sealed record CreateProductCommand(string Name, decimal Price, int AvailableQuantity)
    : IRequest<Result<ProductDto>>;
}


