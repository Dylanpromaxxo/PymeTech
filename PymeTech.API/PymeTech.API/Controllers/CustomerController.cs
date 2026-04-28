using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.API.Common;
using PymeTech.Application.Feature.Customer.Commands.CreateCustomer;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using PymeTech.Application.Feature.Customer.Queries.GetAllCustomers;

namespace PymeTech.API.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator; 

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAllCustomer(CancellationToken ct)
        {
            var data = await _mediator.Send(new GetAllCustomersQuery(), ct);
            return Ok(ApiResponse<List<CustomerDTO>>.Ok(data)); 

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command, CancellationToken ct) 
        {
            var data = await _mediator.Send(command, ct);
            return Ok(ApiResponse<int>.Ok(data, "Creado Exitosamente")); 
        }



    }
}
