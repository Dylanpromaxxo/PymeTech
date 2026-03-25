using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.API.Common;
using PymeTech.Application.Feature.Tenants.Commands.CreateTenant;
using PymeTech.Application.Feature.Tenants.Commands.UpdateTenant;
using PymeTech.Application.Feature.Tenants.Queries.GetAllTenants;
using PymeTech.Application.Feature.Tenants.Queries.GetTenantsById;
using PymeTech.Application.Feature.Tenants.TenantDTOs;
using PymeTech.Domain.Entities;

namespace PymeTech.API.Controllers
{
    [Route("api/v1/tenants")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct) {

            var result = await _mediator.Send(new GetAllTenantsQuery(), ct);
            return Ok(ApiResponse<List<TenantDTO>>.Ok(result));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetTenantByIDQuery { IdTenant = id }, ct);
            return Ok(ApiResponse<TenantDTO>.Ok(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTenantCommand command , CancellationToken ct) 
        {
            var id = await _mediator.Send(command , ct);
            return Ok(ApiResponse<int>.Ok(id, "Tenant Creado Exitosamente"));

         
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id ,  [FromBody] UpdateTenantCommand command , CancellationToken ct) 
        {
            if (id != command.IdTenant) 
            {
                return BadRequest("El id no coincide ");
            }
            var result = await _mediator.Send(command with {IdTenant = id }, ct);
            return Ok(ApiResponse<bool>.Ok(result ,"Tenant Actualizado Exitosamente"));





        
        }

    }
}
