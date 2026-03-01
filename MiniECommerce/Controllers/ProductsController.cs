using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Products.Commands;
using MiniECommerce.Application.Products.Queries;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var command = new CreateProductCommand(dto.Name, dto.Price, dto.AvailableQuantity);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(new { errors = result.Errors });
            }

            return Created("", result.Data);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetProductsQuery(pageNumber, pageSize);
            var result = await _mediator.Send(query);

            return Ok(result.Data);
        }
    }
}


