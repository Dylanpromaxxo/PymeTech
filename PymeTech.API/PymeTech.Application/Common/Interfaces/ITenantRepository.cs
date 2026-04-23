using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface ITenantRepository
    {
        public Task<IReadOnlyList<Tenant>> GetAllAsync(CancellationToken cn);
        public Task<IReadOnlyList<Tenant>> GetDisableAsync(CancellationToken cn);
        public Task<Tenant?> GetByIdAsync(int id ,  CancellationToken cn);
        public Task AddAsync(Tenant tenant, CancellationToken cn);
        public Task UpdateAsync(Tenant tenant, CancellationToken cn); 
        public Task DeleteAsync(Tenant tenant , CancellationToken cn ); 
    }
}
