using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Tenants.TenantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Queries.GetAllTenants
{
    public  class GetAllTenantsHandler : IRequestHandler<GetAllTenantsQuery, List<TenantDTO>>
    {
        private readonly ITenantRepository  _repository ;

        public GetAllTenantsHandler(ITenantRepository repository)
        {
            _repository = repository;
        }



        public async Task<List<TenantDTO>> Handle(GetAllTenantsQuery request, CancellationToken cancellationToken)
        {
            var tenants = await _repository.GetAllAsync(cancellationToken);


            return tenants.Select(tenant => new TenantDTO
            {
                IdTenant = tenant.IdTenant,
                Nombre = tenant.Nombre,
                Email = tenant.Email,
                Telefono = tenant.Telefono,
                PlanSuscripcion = tenant.PlanSuscripcion,
                FechaCreacion = tenant.FechaCreacion,
                Activo = tenant.Activo


            }).ToList() ;
        }
    }
}
