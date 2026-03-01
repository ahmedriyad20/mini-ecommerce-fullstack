using FluentValidation;
using MiniECommerce.Application.Products.Commands;

namespace MiniECommerce.Application.Products.Validators
{

    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(200).WithMessage("Product name cannot exceed 200 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.AvailableQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Available quantity must be greater than or equal to 0");
        }
    }
}
