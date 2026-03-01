using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Customers.Commands
{
    public sealed record CreateCustomerCommand(string FullName, string Phone)
        : IRequest<Result<CustomerDto>>;
}

