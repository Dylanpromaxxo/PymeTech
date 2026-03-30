using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.API.Common;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using PymeTech.Application.Feature.PermisosGlobales.Queries.GetAllPermisos;
using PymeTech.Application.Feature.PermisosGlobales.Queries.GetPermisosByID;

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
            return  Ok(ApiResponse<PermisosDTO>.Ok(response));
        
        }



    }
}
