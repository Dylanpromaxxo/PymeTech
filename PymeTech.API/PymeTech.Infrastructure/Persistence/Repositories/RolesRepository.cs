using Microsoft.EntityFrameworkCore;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly AppDbContext _context;


        public RolesRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<int> AddAsync(Rol rol, CancellationToken ct)
        {
            await _context.Roles.AddAsync(rol);
            await _context .SaveChangesAsync(ct); 
            return rol.IdRol; 

        }

        public async Task<Rol?> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.IdRol == id, ct); 
        }

        public async Task<IReadOnlyList<Rol>> GetRolbyIdTenantAsync(int idTenat, CancellationToken ct)
        {
            return await  _context.Roles.Where(r=> r.IdTenant == idTenat).ToListAsync(ct);

        }

        public async Task UpdateAsync(Rol rol, CancellationToken ct)
        {
             _context.Roles.Update(rol);
            await _context.SaveChangesAsync(ct); 

        }
    }
}
