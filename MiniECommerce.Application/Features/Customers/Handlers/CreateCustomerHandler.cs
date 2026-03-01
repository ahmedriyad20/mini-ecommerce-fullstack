using FluentValidation;
using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Application.Customers.Commands;
using MiniECommerce.Domain.Entities;
using MiniECommerce.Service.Interfaces;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Customers.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Result<CustomerDto>>
    {
        private readonly ICustomerService _customerService;
        private readonly IValidator<CreateCustomerCommand> _validator;

        public CreateCustomerHandler(ICustomerService customerService, IValidator<CreateCustomerCommand> validator)
        {
            _customerService = customerService;
            _validator = validator;
        }

        public async Task<Result<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<CustomerDto>.Failure(errors);
            }

            var customer = new Customer { Id = Guid.NewGuid(), FullName = request.FullName, Phone = request.Phone };

            await _customerService.CreateCustomer(customer);

            var customerDto = new CustomerDto(customer.Id, customer.FullName, customer.Phone);

            return Result<CustomerDto>.Success(customerDto);
        }
    }
}


