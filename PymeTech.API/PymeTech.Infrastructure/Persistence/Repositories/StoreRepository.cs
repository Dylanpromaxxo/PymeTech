using Microsoft.EntityFrameworkCore;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Store.DTOS;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence.Repositories
{
    public class StoreRepository : IStroreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }





        public async Task<PagedResult<StoreSummaryDTO>> GetAllAsync(int idTenant, int pageNumber, int pageSize, bool? Activo, CancellationToken ct)
        {
            var query = _context.Almacenes.AsNoTracking().Where(s => s.IdTenant == idTenant);

            if (Activo.HasValue) 
            {
                query.Where(s => s.Activo == Activo);
            }


            var totalRecords = await query.CountAsync(ct);

            var itmes = await query.OrderBy(s => s.Nombre)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new StoreSummaryDTO
                {
                    idStore = c.IdAlmacen,
                    Nombre = c.Nombre,
                    Descripcion = c.Nombre,
                    Activo = c.Activo,
                    Esprincipal = c.EsPrincipal

                }).ToListAsync(ct);


            return new PagedResult<StoreSummaryDTO>
            {
                PageNumber = pageNumber , 
                PageSize = pageSize, 
                TotalPages =(int)Math.Ceiling(totalRecords / (double)pageSize), 
                Items = itmes
                
         
            };


        }

        public async Task<Almacenes> GetById(int idTenant, int idStore, CancellationToken ct)
        {
            return await _context.Almacenes.Where(c => c.IdTenant == idTenant && c.IdAlmacen == idStore).FirstOrDefaultAsync(ct);
                
        }
    }
}
