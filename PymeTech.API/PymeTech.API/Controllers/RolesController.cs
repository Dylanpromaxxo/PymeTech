using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.API.Common;
using PymeTech.Application.Feature.roles.Commands.ChangeStatusRol;
using PymeTech.Application.Feature.roles.Commands.CreateRol;
using PymeTech.Application.Feature.roles.Commands.UpdateRol;
using PymeTech.Application.Feature.roles.Queries.GetRolesbyIdTenant;
using PymeTech.Application.Feature.roles.rolesDTOs;

namespace PymeTech.API.Controllers
{
    [Route("api/v1/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            
            _mediator = mediator; 
        }

        [HttpGet("{idTenant}")]
        public async Task<IActionResult> GetRolbyIdTenant(int idTenant, CancellationToken ct) 
        {
            var result = await _mediator.Send(new GetRolesByIdTenantCommand { IdTenant = idTenant }, ct); 
            return Ok(ApiResponse<List<RolesDTO>>.Ok(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRol([FromBody] CreateRolCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return Ok(ApiResponse<int>.Ok(id, "Rol Creado Exitosamente"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRol (int id ,  [FromBody] UpdateRolCommand command , CancellationToken  ct)
        {
            if (command.IdRol != id)
            {
                return BadRequest(ApiResponse<string>.Fail("El Id del Rol no coincide con el Id de la ruta"));
            }
            var result = await _mediator.Send (command, ct);
            return Ok(ApiResponse<bool>.Ok(result, "Rol Actualizado Correctamente "));

        }

        [HttpPatch("ChangeStatus/{id}")]
        public async Task<IActionResult> ChangeStatus (int id , CancellationToken ct) 
        {
           
            var data = await _mediator.Send(new ChangeStatusRolCommand { IdRol = id}, ct);
            return Ok(ApiResponse<bool>.Ok(data, "Estado Cambiado")); 
        }
    }
}
