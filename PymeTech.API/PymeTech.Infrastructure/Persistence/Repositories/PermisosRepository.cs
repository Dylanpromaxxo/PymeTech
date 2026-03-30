using Microsoft.EntityFrameworkCore;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
