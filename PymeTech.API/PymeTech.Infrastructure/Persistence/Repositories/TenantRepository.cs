using Microsoft.EntityFrameworkCore;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;


namespace PymeTech.Infrastructure.Persistence.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _context;

        public TenantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Tenant tenant, CancellationToken cn)
        {
           await _context.Tenants.AddAsync(tenant ,cn );
            await _context.SaveChangesAsync(cn);
            return tenant.IdTenant;

        }

        public async Task DeleteAsync(Tenant tenant, CancellationToken cn)
        {
            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync(cn);
        }

        public async Task<IReadOnlyList<Tenant>> GetAllAsync(CancellationToken cn)
        {
            return await _context.Tenants.Where(ac => ac.Activo).OrderBy(n => n.Nombre).ToListAsync(cn); 
        }

        public async Task<Tenant?> GetByIdAsync(int id, CancellationToken cn)
        {
            return await _context.Tenants.FirstOrDefaultAsync(c => c.IdTenant == id, cn);
        }

        public async Task UpdateAsync(Tenant tenant, CancellationToken cn)
        {
            _context.Tenants.Update(tenant); 
            await _context.SaveChangesAsync(cn);
        }
    }
}
