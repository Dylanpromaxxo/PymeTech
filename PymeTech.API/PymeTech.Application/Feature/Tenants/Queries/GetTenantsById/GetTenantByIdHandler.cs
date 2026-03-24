using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Tenants.Queries.GetAllTenants;
using PymeTech.Application.Feature.Tenants.TenantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Queries.GetTenantsById
{
    public class GetTenantByIdHandler : IRequestHandler<GetTenantByIDQuery, TenantDTO>
    {
        private readonly ITenantRepository _repository;

        public GetTenantByIdHandler(ITenantRepository repositorio) 
        { 
        
            _repository = repositorio; 
        
        }



        public async Task<TenantDTO> Handle(GetTenantByIDQuery request, CancellationToken cancellationToken)
        {
            var tenant = await _repository.GetByIdAsync(request.IdTenant, cancellationToken);

            if (tenant == null)
            {
                throw new Exception("Tenant no existe");
            }

            return new TenantDTO {
                IdTenant = tenant.IdTenant, 
                Nombre = tenant.Nombre, 
                Email = tenant.Email, 
                Telefono = tenant.Telefono, 
                PlanSuscripcion = tenant.PlanSuscripcion, 
                FechaCreacion = tenant.FechaCreacion, 
                Activo = tenant.Activo, 

            
            
            }; 
                
            

        }
    }
}
