using Microsoft.EntityFrameworkCore;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence.Repositories
{
    public class PermisosRepository: IPermisosRepository
    {
        private readonly AppDbContext _dbContext;

        public PermisosRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext; 

        }

        public async Task<IReadOnlyList<Permisos>> GetAllAsync(CancellationToken ct)
        {
            var Permisos = await _dbContext.Permisos.OrderBy(n=> n.Modulo).ToListAsync(ct) ; 
            return Permisos ;
        }

        public async Task<Permisos?> GetByIdAsync(int id, CancellationToken ct)
        {
            return  await _dbContext.Permisos.FirstOrDefaultAsync(p => p.IdPermiso == id, ct);
            
        }

        public async Task<IReadOnlyList<Permisos>> GetByModuloAsync(string modulo , string? accion, CancellationToken ct)
        {
            var query = _dbContext.Permisos.AsQueryable(); //No ejecuta la query hasta listar 
            query = query.Where(p => p.Modulo.ToLower().Contains(modulo.ToLower()));
            if (!string.IsNullOrWhiteSpace(accion))//validad que no venga null o con espacios
                query = query.Where(p => p.Accion.ToLower().Contains(accion.ToLower()));



            return await query.OrderBy(p=> p.Modulo ).ThenBy(p=> p.Accion).ToListAsync(); // ejecuta le query 
        }

        public async Task<int> AddAsync(Permisos permisos, CancellationToken cancellationToken) 
        {
             await _dbContext.AddAsync(permisos ,cancellationToken); 
             await  _dbContext.SaveChangesAsync();
            return permisos.IdPermiso; 
        

        }

        public async Task DeleteAsync(Permisos permisos, CancellationToken ct)
        {
            _dbContext.Permisos.Remove(permisos);
            await _dbContext.SaveChangesAsync(ct); 


        }
    }
}
