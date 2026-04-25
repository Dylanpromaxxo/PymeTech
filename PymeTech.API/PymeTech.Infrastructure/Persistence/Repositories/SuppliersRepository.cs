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
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly AppDbContext _context;
        public SuppliersRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<List<Proveedores>> GetAllAsync(int idTenant)
        {
            return await _context.Proveedores.Where(s => s.IdTenant == idTenant).ToListAsync();

        }
    }
}
