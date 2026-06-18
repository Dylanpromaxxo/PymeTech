using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.suppliers.SuppliersDTOs;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface ISuppliersRepository
    {
        Task<PagedResult<SupplerSummaryDTO>> GetPagedAsync(int idTenant, int pageNumber, int pageSize, string? search, bool? activo, CancellationToken ct);
        Task<PagedResult<SupplerSummaryDTO>> GetAllPageedAsync(int IdTenat , int pageNumber , int pageSize , CancellationToken ct );
        Task<Proveedores> GetByIdAsync(int idTenant, int IdSupplier, CancellationToken ct);
        Task Create(Proveedores provedores, CancellationToken ct);
        Task Update(Proveedores provedores, CancellationToken ct);
        



    }
}
