using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface IRolesRepository
    {
         Task<IReadOnlyList<Rol>> GetRolbyIdTenantAsync(int idTenant , CancellationToken ct); 
         Task<int> AddAsync(Rol rol, CancellationToken ct);
        Task<Rol?> GetByIdAsync(int id, CancellationToken ct); 
        Task UpdateAsync(Rol rol, CancellationToken ct ); 

    }
}
