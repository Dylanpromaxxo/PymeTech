using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using PymeTech.Application.Feature.Tenants.Queries.GetTenantsDesctivados;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface IPermisosRepository
    {
        public Task<IReadOnlyList<Permisos>> GetAllAsync(CancellationToken ct);
        public Task<Permisos?> GetByIdAsync(int id, CancellationToken ct);

    }
}
