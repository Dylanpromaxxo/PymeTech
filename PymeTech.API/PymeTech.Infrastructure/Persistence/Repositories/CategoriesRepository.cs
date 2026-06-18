using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Categories.DTOS;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private readonly AppDbContext _context; 



        public CategoriesRepository(AppDbContext context    )
        {
            _context = context;
        }



      

        public async Task<Categoria> GetByIdAsync(int idTenant, int idCategories, CancellationToken ct)
        {
            return await _context.Categoria.Where(c => c.IdTenant == idTenant && c.IdCategoria == idCategories).FirstOrDefaultAsync(ct);
        }

        public async Task<PagedResult<CategoriesDTO>> GetPagend(int idTenant, int pageSize, int pageNumber, bool? activo , CancellationToken ct)
        {
            var query = _context.Categoria.AsNoTracking().Where(c => c.IdTenant == idTenant);

            if(activo.HasValue)
            {
                query = query.Where(c => c.Activo == activo.Value);
            }
            var totalRecords = await query.CountAsync(ct);

            var data = await query.OrderBy(c => c.Nombre)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CategoriesDTO
                {
                    IdCategoria = c.IdCategoria ,
                    Nombre = c.Nombre , 
                    Descripcion = c.Descripcion , 
                    FechaCreacion = c.FechaCreacion , 
                    Activo = c.Activo , 
                    FechaActualizacion = c.FechaActualizacion 
                    

                }).ToListAsync(ct);


            return new PagedResult<CategoriesDTO>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = (int)Math.Ceiling(totalRecords / (double)pageSize),
                Items = data
            };
     



        }
    }
}
