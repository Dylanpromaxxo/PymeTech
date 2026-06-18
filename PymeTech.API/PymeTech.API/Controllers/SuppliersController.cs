using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.API.Common;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.suppliers.Commands.Create;
using PymeTech.Application.Feature.suppliers.Commands.de_ete;
using PymeTech.Application.Feature.suppliers.Commands.Update;
using PymeTech.Application.Feature.suppliers.Queries.GetAllSuppliers;
using PymeTech.Application.Feature.suppliers.Queries.GetPagendSuppliers;
using PymeTech.Application.Feature.suppliers.Queries.GetSupplierById;
using PymeTech.Application.Feature.suppliers.SuppliersDTOs;
using System.Runtime.InteropServices;

namespace PymeTech.API.Controllers
{
    [Route("api/v1/Suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator _meditor;

        public SuppliersController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> Pagened([FromQuery] int pageNumber, [FromQuery] int PageSize, [FromQuery] string? search, bool? activo, CancellationToken ct)
        {
            var data = await _meditor.Send(new GetPaginedSupplierQuery { PageNumber = pageNumber, PageSize = PageSize, Activo = activo, Search = search }, ct);
            return Ok(ApiResponse<PagedResult<SupplerSummaryDTO>>.Ok(data));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber  = 1 , [FromQuery] int pageSize = 10 ,   CancellationToken ct = default) 
        {
            var data = await _meditor.Send(new GetAllSuppliersQuery { PageNumber = pageNumber , PageSize = pageSize } , ct);
            return Ok(ApiResponse<PagedResult<SupplerSummaryDTO>>.Ok(data));

        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetbyId(int id, CancellationToken ct) 
        {
            var data = await _meditor.Send(new GetSupplierByIdQuery { IdSupplier = id }, ct);
            return Ok(ApiResponse<SupplerDTO>.Ok(data));

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateSuppliercommand request , CancellationToken ct)  
        {
            var data = await _meditor.Send(request, ct);
            return Ok(ApiResponse<int>.Ok(data));

        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> update([FromBody] UpdateSupplierCommand request, CancellationToken ct) 
        {
            var data = await _meditor.Send(request, ct);
            return Ok(ApiResponse<bool>.Ok(data));
        }


        [HttpPatch("{id}/status")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus(int id, CancellationToken cancellationToken) 
        {
            var data = await _meditor.Send(new DeleteSupplierCommad { idProveedor = id }, cancellationToken);
            return Ok(ApiResponse<bool>.Ok(data));
        }




    }
}
