using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using PymeTech.Domain.Entities;


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

        public async Task<Clientes> GetByIdAsync(int idTenant, int idCliente, CancellationToken ct)
        {
            return await _context.Clientes.Where(c => c.IdTenant == idTenant && c.IdCliente == idCliente).FirstOrDefaultAsync(ct); 
        }

        public async Task<PagedResult<SummaryCustomerDTO>> GetPagedAsync(int idTenant, int pageNumber, int pageSize, string? search, bool? activo, CancellationToken ct)
        {
            var query =  _context.Clientes.AsNoTracking().Where(c => c.IdTenant == idTenant);

            if (activo.HasValue) 
            {
                query = query.Where(c => c.Activo == activo.Value);
            }

            if (!string.IsNullOrWhiteSpace(search)) 
            {
                var serachValue = search.Trim().ToLower();

                query = query.Where(c =>
    c.RazonSocial.ToLower().Contains(serachValue) ||
    (c.NombreContacto != null && c.NombreContacto.ToLower().Contains(serachValue)) ||
    (c.Email != null && c.Email.ToLower().Contains(serachValue)) ||
    (c.Telefono != null && c.Telefono.ToLower().Contains(serachValue)));
            }

            var totalRecords = await query.CountAsync(ct);

            var items = await query
                .OrderBy(c => c.RazonSocial)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new SummaryCustomerDTO 
                {
                    idCliente = c.IdCliente, 
                    TipoDocumento = c.TipoDocumento, 
                    NombreContacto = c.NombreContacto, 
                    Email = c.Email,
                    Telefono = c.Telefono,
                    Activo = c.Activo, 
                    FechaCreacion = c.FechaCreacion 
                }).ToListAsync(ct);


            return new PagedResult<SummaryCustomerDTO>
            {
                PageNumber = pageNumber, 
                PageSize = pageSize , 
                TotalRecords = totalRecords , 
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
                Items = items , 
            };
        }

        public async Task<IReadOnlyList<Clientes>> SearchAsync(int idTenant, string filter, CancellationToken ct)
        {
            return await _context.Clientes.Where(c => c.IdTenant == idTenant && (c.RazonSocial.Contains(filter) || c.NumeroDoc.Contains(filter) || c.Email.Contains(filter) || c.Telefono.Contains(filter))).ToListAsync(ct);
        }
    }
}
