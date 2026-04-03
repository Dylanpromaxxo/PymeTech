using Microsoft.EntityFrameworkCore;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using PymeTech.Application.Common.Exceptions; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            await _context.Roles.AddAsync(rol ,ct );
            await _context .SaveChangesAsync(ct); 
            return rol.IdRol; 

        }

        //role-permission

        public async Task AssignPermissionToRolAsync(RolPermiso rol  ,  CancellationToken ct)
        {
             await _context.RolPermisos.AddAsync(rol , ct );
             await _context.SaveChangesAsync(ct);

        }

        public async Task<Rol?> GetByIdAsync(int id  ,int idTenat, CancellationToken ct)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.IdRol == id && r.IdTenant == idTenat  , ct); 
        }

        public async Task<IReadOnlyList<Rol>> GetRolbyIdTenantAsync(int idTenat, CancellationToken ct)
        {
            return await  _context.Roles.Where(r=> r.IdTenant == idTenat).ToListAsync(ct);

        }

        public async Task RemovePermissionToRolAsync(int idTenant, int idRol, int IdPermisos, CancellationToken ct)
        {
            var rolPermiso = await _context.RolPermisos.FirstOrDefaultAsync(c => c.IdTenant == idTenant && c.IdRol == idRol && c.IdPermiso == IdPermisos, ct);
            if (rolPermiso == null)
                throw new NotFoundException("RolPermiso", $"Rol:{idRol}/Permiso:{IdPermisos}");


            _context.RolPermisos.Remove(rolPermiso);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Rol rol, CancellationToken ct)
        {
             _context.Roles.Update(rol);
            await _context.SaveChangesAsync(ct); 

        }



    }
}
