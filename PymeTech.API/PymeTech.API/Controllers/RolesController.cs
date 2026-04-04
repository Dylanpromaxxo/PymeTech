
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.API.Common;
using PymeTech.Application.Feature.roles.Commands.ChangeStatusRol;
using PymeTech.Application.Feature.roles.Commands.CreateRol;
using PymeTech.Application.Feature.roles.Commands.UpdateRol;
using PymeTech.Application.Feature.roles.Queries.GetRolesbyIdTenant;
using PymeTech.Application.Feature.roles.Queries.GetRolWithPermission;
using PymeTech.Application.Feature.roles.rolesDTOs;
using PymeTech.Application.Feature.roles.RolPermisoss.Command.AssignPermission;
using PymeTech.Application.Feature.roles.RolPermisoss.Command.RemovePermission;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

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

        [HttpPut("{idTenant}/{idRol}")]
        public async Task<IActionResult> UpdateRol (int idRol, int idTenant,  [FromBody] UpdateRolRequest request , CancellationToken  ct)
        {
           var command = new UpdateRolCommand { IdRol = idRol, IdTenant = idTenant, Nombre = request.Nombre, Descripcion = request.Descripcion }; 
           var result = await _mediator.Send(command, ct); 
            return Ok(ApiResponse<bool>.Ok(result, "Rol Actualizado Exitosamente")); 
        }

        [HttpPatch("ChangeStatus/{id}/{idTenant}")]
        public async Task<IActionResult> ChangeStatus (int id , int idTenant , CancellationToken ct) 
        {
           
            var data = await _mediator.Send(new ChangeStatusRolCommand { IdRol = id , IdTenant = idTenant}, ct);
            return Ok(ApiResponse<bool>.Ok(data, "Estado Cambiado")); 
        }

        [HttpPost("{idTenant}/roles/{idRol}/permisos/{idPermiso}")]
        public async Task<IActionResult> AssignPermissionToRol(int idTenant , int idRol , int idPermiso ,[FromQuery] int? asignadoPor, CancellationToken ct)
        {
            var result = await _mediator.Send(new AssignPermissionCommand { IdTenant = idTenant , IdRol = idRol , IdPermisos = idPermiso,  AsignadoPor = asignadoPor }, ct);
            return Ok(ApiResponse<bool>.Ok(result, "Permiso Asignado al Rol Correctamente"));

        }

        [HttpDelete("{idTenant}/roles/{idRol}/permisos/{idPermiso}")]
        public async Task<IActionResult> RemovePermissionToRol(int idTenant, int idRol, int idPermiso, CancellationToken ct)
        {
            var result = await _mediator.Send(new RemovePermissionCommand { IdTenant = idTenant, IdRol = idRol, IdPermisos = idPermiso }, ct);
            return Ok(ApiResponse<bool>.Ok(result, "Permiso Removido del Rol Correctamente"));
        }



        [HttpGet("{idTenant}/{idRol}/Permission")]
        public async Task<IActionResult> GetRolWithPermission(int idTenant, int idRol, CancellationToken ct) 
        {
            var rol = await _mediator.Send(new GetRolWithPermissionCommand { IdRol = idRol, IdTenant = idTenant }, ct);
            return Ok(ApiResponse<RolesDetailsDTO>.Ok(rol)); 
        }

    }
}
