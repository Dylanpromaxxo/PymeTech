using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.Application.Feature.Categories.Queries.GetAll;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using PymeTech.API.Common;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Categories.DTOS;
using PymeTech.Application.Feature.Categories.Queries.GetByID;
using PymeTech.Application.Feature.Categories.Commands.Create;
using Microsoft.EntityFrameworkCore.Update.Internal;
using PymeTech.Application.Feature.Categories.Commands.Update;
using PymeTech.Application.Feature.Categories.Commands.ChangeStatus;

namespace PymeTech.API.Controllers
{
    [Route("api/v1/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator meditor)
        {
            _mediator = meditor;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumer = 1, [FromQuery] int pageSize = 10, [FromQuery] bool? acitvo = true, CancellationToken ct = default)
        {
            var data = await _mediator.Send(new GetAllCategoriesQuery { PageNumber = pageNumer, PageSize = pageSize, Activo = acitvo }, ct);
            return Ok(ApiResponse<PagedResult<CategoriesDTO>>.Ok(data));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetbyId(int id, CancellationToken ct)
        {
            var data = await _mediator.Send(new GetCategoriesByIdQuery { CategoriId = id }, ct);
            return Ok(ApiResponse<CategoriesDTO>.Ok(data));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateCategoriCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return Ok(ApiResponse<int>.Ok(id));
        }

        [HttpPut]
        [Authorize]

        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command, CancellationToken ct)
        {
            var data = await _mediator.Send(command, ct);
            return Ok(ApiResponse<int>.Ok(data));
        }

        [HttpPatch("{id}/change")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus (int id , CancellationToken ct) 
        {
            var data = await _mediator.Send(new ChangeStatusCategoryCommad { IdCategory = id }, ct);
            return Ok(ApiResponse<Unit>.Ok(data));

        }






    }
}
