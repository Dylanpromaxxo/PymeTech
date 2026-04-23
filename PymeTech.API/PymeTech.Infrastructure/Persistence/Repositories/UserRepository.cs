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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> AddAsync(Usuario usuario, CancellationToken ct)
        {
            await _context.Usuarios.AddAsync(usuario, ct);    
            await _context.SaveChangesAsync(ct);
            return usuario;
        }

        public async Task<bool> EmailExistaAsync( string email, CancellationToken ct)
        {
             return await _context.Usuarios.AnyAsync(u =>  u.Email == email, ct);
        }

        public async Task<Usuario> GetByEmailAsync(int idTenant, string email, CancellationToken ct)
        {
            return await _context.Usuarios.Include(r=> r.Rol).Where(u=> u.IdTenant == idTenant && u.Email== email ).FirstOrDefaultAsync(ct);

        }

        public async Task<bool> UpdateAsync(Usuario usuario, CancellationToken ct)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync(ct);  
            return true;
        }
    }
}
