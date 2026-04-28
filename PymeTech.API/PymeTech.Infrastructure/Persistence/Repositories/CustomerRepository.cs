using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository 
    {
        private readonly AppDbContext _context;


        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Clientes clinetes, CancellationToken ct)
        {
            await _context.Clientes.AddAsync(clinetes, ct); 
        }

        public async Task<IReadOnlyList<Clientes>> GetAllCustomer(int idTenant, CancellationToken ct)
        {
            return await _context.Clientes.Where(c => c.IdTenant == idTenant).OrderBy(c=>c.NombreContacto).ToListAsync();
            

        }
    }
}
