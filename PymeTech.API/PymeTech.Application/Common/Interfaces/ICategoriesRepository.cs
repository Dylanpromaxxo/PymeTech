using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Categories.DTOS;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface ICategoriesRepository
    {
     
        Task<Categoria> GetByIdAsync(int idTenant, int idCategories, CancellationToken ct);
        Task<PagedResult<CategoriesDTO>> GetPagend(int idTenant, int pageSize, int pageNumber, bool? activo, CancellationToken ct); 

    }
}
