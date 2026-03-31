using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.API.Common;
using PymeTech.Application.Feature.PermisosGlobales.Commands.CreatePermisos;
using PymeTech.Application.Feature.PermisosGlobales.Commands.DeletePermisos;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using PymeTech.Application.Feature.PermisosGlobales.Queries.GetAllPermisos;
using PymeTech.Application.Feature.PermisosGlobales.Queries.GetPermisosByID;
using PymeTech.Application.Feature.PermisosGlobales.Queries.GetPermisosByModulo;
using System.Runtime.InteropServices;

namespace PymeTech.API.Controllers
{
    [Route("api/v1/Permisos")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PermisosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken ct)
        {
            var resposne = await _mediator.Send(new GetAllPermisosCommand(), ct);
            return Ok(ApiResponse<List<PermisosDTO>>.Ok(resposne));

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetPermisosByIDCommand { IdPermisos = id }, ct);
            return Ok(ApiResponse<PermisosDTO>.Ok(response));

        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetByModulo([FromQuery] string modulo, [FromQuery] string? accion, CancellationToken ct) 
        {
            var data = await _mediator.Send(new GetPermisosByModuloCommand { Modulo = modulo, Accion = accion }, ct);
            return Ok(ApiResponse<List<PermisosDTO>>.Ok(data));
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreatePermisosCommand command, CancellationToken ct) 
        {
            var response = await _mediator.Send(command, ct);
            return Ok(ApiResponse<int>.Ok(response, "Permiso Creado"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id ,  CancellationToken ct)
        {
            var response = await  _mediator.Send(new DeletePermisoCommand { IdPermisos = id }, ct);
            return Ok(ApiResponse<bool>.Ok(response, "Permiso Eliminado")); 
        }
    }
}
