using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.Application.Feature.Store.Queries.GetAll;
using PymeTech.API.Common;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Store.DTOS;
using PymeTech.Application.Feature.Store.Queries.GetById;

namespace PymeTech.API.Controllers
{
    [Route("api/v1/Store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _meditor;

        public StoreController( IMediator meditor)
        {
            _meditor = meditor; 
            
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] bool? activo, CancellationToken ct)
        {
            var data = await _meditor.Send(new GetAllStoreQuery { PageNumber = pageNumber, PageSize = pageSize, Activo = activo }, ct);
            return Ok(ApiResponse<PagedResult<StoreSummaryDTO>>.Ok(data));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var data = await _meditor.Send(new GetStoreByIdQuery { IdStore = id }, ct);
            return Ok(ApiResponse<StoreDTO>.Ok(data));
        }
    }
}
