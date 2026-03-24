using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.Application.Feature.Tenants.Commands;
using PymeTech.Application.Feature.Tenants.Queries.GetAllTenants;
using PymeTech.Application.Feature.Tenants.Queries.GetTenantsById;
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
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetTenantByIDQuery { IdTenant = id }, ct);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTenantCommand command , CancellationToken ct) 
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id }, new { IdTenant = id });
        }

    }
}
