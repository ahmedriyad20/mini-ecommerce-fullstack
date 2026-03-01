using FluentValidation;
using MediatR;
using MiniECommerce.Application.Common;
using MiniECommerce.Application.Products.Commands;
using MiniECommerce.Domain.Entities;
using MiniECommerce.Service.Interfaces;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<ProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductCommand> _validator;

        public CreateProductHandler(IProductService productService, IValidator<CreateProductCommand> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<ProductDto>.Failure(errors);
            }

            // Validate the product quantity first
            if(request.AvailableQuantity <= 0)
                return Result<ProductDto>.Failure("Available quantity must be greater than zero.");

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                AvailableQuantity = request.AvailableQuantity,
            };

            await _productService.CreateProduct(product);

            var dto = new ProductDto(
                product.Id,
                product.Name,
                product.Price,
                product.AvailableQuantity
            );

            return Result<ProductDto>.Success(dto);
        }
    }
}


