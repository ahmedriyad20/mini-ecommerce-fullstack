using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Common;
using MiniECommerce.Application.Orders.Commands;
using MiniECommerce.Domain.Entities;
using MiniECommerce.Service.Interfaces;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Application.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result<OrderDto>>
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IValidator<CreateOrderCommand> _validator;

        public CreateOrderHandler(IOrderService orderService, IProductService productService, IValidator<CreateOrderCommand> validator)
        {
            _orderService = orderService;
            _productService = productService;
            _validator = validator;
        }

        public async Task<Result<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Validate request
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<OrderDto>.Failure(errors);
            }

            // Get all products from the order
            var productIds = request.Items.Select(i => i.ProductId).ToList();
            var products = await _productService.GetAllProducts(1, int.MaxValue)
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync(cancellationToken);

            // Validate that all products are exist and have enogh stock quantity
            foreach (var item in request.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product is null)
                {
                    return Result<OrderDto>.Failure("Product Not Exists!");
                }

                if (product.AvailableQuantity < item.Quantity)
                {
                    // Here is the condition if the stock quantity is not enogh
                    return Result<OrderDto>.Failure($"Not Enogh stock quantity for product {product.Name}");
                }
            }

            // Create order
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                OrderDate = DateTimeOffset.Now,
                OrderItems = new List<OrderItem>()
            };

            // Create order items and update stock
            foreach (var item in request.Items)
            {
                var product = products.First(p => p.Id == item.ProductId);

                var orderItem = new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                ((List<OrderItem>)order.OrderItems).Add(orderItem);

                // update the stock quantiy for each product
                product.AvailableQuantity -= item.Quantity;
                await _productService.UpdateProduct(product);
            }

            // Save order using service
            var createdOrder = await _orderService.CreateOrder(order);

            var orderDto = new OrderDto(
                createdOrder.Id,
                createdOrder.CustomerId,
                createdOrder.OrderDate,
                createdOrder.OrderItems.Select(oi =>
                {
                    // Get the product name for each OrderItem to display it
                    var product = products.First(p => p.Id == oi.ProductId);
                    return new OrderItemDto(
                        oi.Id,
                        oi.ProductId,
                        product.Name,
                        oi.Quantity,
                        oi.UnitPrice,
                        oi.LineTotal
                    );
                }).ToList(),
                createdOrder.TotalItems,
                createdOrder.Subtotal,
                createdOrder.DiscountPercentage,
                createdOrder.DiscountAmount,
                createdOrder.Total
            );

            return Result<OrderDto>.Success(orderDto);
        }
    }
}


