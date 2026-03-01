using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Application.Customers.Queries;
using MiniECommerce.Service.Interfaces;
using MiniECommerce.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MiniECommerce.Application.Customers.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, Result<PagedResult<CustomerDto>>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomersHandler( ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Result<PagedResult<CustomerDto>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var query = _customerService.GetAllCustomers();

            var totalCount = await query.CountAsync();

            var customers = await query.OrderBy(c => c.FullName)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new CustomerDto(
                    c.Id,
                    c.FullName,
                    c.Phone
                ))
                .ToListAsync();

            var result = new PagedResult<CustomerDto>
            {
                Items = customers,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            return Result<PagedResult<CustomerDto>>.Success(result);
        }
    }
}
