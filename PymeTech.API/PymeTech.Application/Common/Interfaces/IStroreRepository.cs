using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Store.DTOS;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface IStroreRepository 
    {
        Task<PagedResult<StoreSummaryDTO>> GetAllAsync(int IdTenant ,  int pageNumber, int pageSize, bool? Activo, CancellationToken ct);
        Task<Almacenes> GetById(int idTenant, int idStore, CancellationToken ct);
        
    }
}
