using FluentValidation;
using MiniECommerce.Application.Orders.Commands;

namespace MiniECommerce.Application.Orders.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("Order must have at least one item");
        }
    }
}


