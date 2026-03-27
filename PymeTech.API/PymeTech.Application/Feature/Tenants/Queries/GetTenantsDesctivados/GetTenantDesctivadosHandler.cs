using MediatR;
using Microsoft.IdentityModel.Tokens;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Tenants.TenantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Queries.GetTenantsDesctivados
{
    public class GetTenantDesctivadosHandler : IRequestHandler<GetTenantDesactivadosQuery, List<TenantDTO>>
    {
        private readonly ITenantRepository _Repository;

        public GetTenantDesctivadosHandler(ITenantRepository repo )
        {
            _Repository = repo; 
            
        }


        public async Task<List<TenantDTO>> Handle(GetTenantDesactivadosQuery request, CancellationToken cancellationToken)
        {
            var tenants = await _Repository.GetDisableAsync(cancellationToken);

            return tenants.Select(tenants => new TenantDTO { 
            IdTenant = tenants.IdTenant,
            Nombre = tenants.Nombre, 
            Email = tenants.Email, 
            Telefono = tenants.Telefono, 
            Activo = tenants.Activo, 
            FechaCreacion = tenants.FechaCreacion, 
            PlanSuscripcion = tenants.PlanSuscripcion, 
            
            }).ToList();

            


        }


    }
}
