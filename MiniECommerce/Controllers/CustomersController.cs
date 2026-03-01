using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Customers.Commands;
using MiniECommerce.Application.Customers.Queries;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            var command = new CreateCustomerCommand(dto.FullName, dto.Phone);
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
            var query = new GetCustomersQuery(pageNumber, pageSize);
            var result = await _mediator.Send(query);

            return Ok(result.Data);
        }
    }
}
