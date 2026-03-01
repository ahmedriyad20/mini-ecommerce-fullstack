using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Customers.Queries
{
    public sealed record GetCustomersQuery(int PageNumber = 1, int PageSize = 10)
    : IRequest<Result<PagedResult<CustomerDto>>>;
}


