using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PymeTech.API.Common;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Customer.Commands.ChangeStatus;
using PymeTech.Application.Feature.Customer.Commands.CreateCustomer;
using PymeTech.Application.Feature.Customer.Commands.Search;
using PymeTech.Application.Feature.Customer.Commands.UpdateCustomer;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using PymeTech.Application.Feature.Customer.Queries.GetAllCustomers;
using PymeTech.Application.Feature.Customer.Queries.GetByIdCustomer;
using PymeTech.Application.Feature.Customer.Queries.GetCustomerPaged;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Authorize]
        public async Task<IActionResult> GetAllCustomer(CancellationToken ct)
        {
            var data = await _mediator.Send(new GetAllCustomersQuery(), ct);
            return Ok(ApiResponse<List<SummaryCustomerDTO>>.Ok(data)); 

        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerbyId(int id, CancellationToken ct) 
        {
            var data = await _mediator.Send(new GetByIdCustomerQuery { IdCliente = id }, ct);
            return Ok(ApiResponse<CustomerDTO>.Ok(data));
        }




        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command, CancellationToken ct) 
        {
            var data = await _mediator.Send(command, ct);
            return Ok(ApiResponse<int>.Ok(data, "Creado Exitosamente")); 
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerRequest request, CancellationToken ct) 
        {
            var data = await _mediator.Send(new UpdateCustomerCommand
            {
                IdCliente = id,
                RazonSocial = request.RazonSocial,
                Direccion = request.Direccion,
                Email = request.Email,
                NumeroDocumento = request.NumeroDocumento,
                NombreContacto = request.NombreContacto,
                Telefono = request.Telefono,
                TipoCliente = request.TipoCliente,
                TipoDocumento = request.TipoDocumento
            }, ct);


            return Ok(ApiResponse<bool>.Ok(data, "Actulizado Correctamente ")); 

        }

        [HttpPatch("{id}/status")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus(int id ,CancellationToken ct ) 
        {
            var data = await _mediator.Send(new ChangeStatusCustomerCommand { IdCliente = id }, ct);
            return Ok(ApiResponse<bool>.Ok(data ));
        }

        [HttpGet("seach")]
        [Authorize]
        public async Task<IActionResult> Seach(string filter , CancellationToken ct ) 
        {
            var data = await _mediator.Send(new SearchCustomerCommand { Filter = filter }, ct);
            return Ok(ApiResponse<List<SummaryCustomerDTO>>.Ok(data));
        }


        [HttpGet("paged") ] 
        [Authorize]
        public async Task<IActionResult> GetCustomersPaged(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] bool? activo = true,
            CancellationToken ct = default)
        {
            var query = new GetCustomerPagedQuery 
            {
                PageNumber = pageNumber , 
                PageSize = pageSize , 
                Seach = search, 
                Activo = activo 

            };

            var data = await _mediator.Send(query, ct);

            return Ok(ApiResponse<PagedResult<SummaryCustomerDTO>>.Ok(data));
        }

    }
}
