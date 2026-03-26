using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PymeTech.Application.Common.Exceptions;

namespace PymeTech.Application.Feature.Tenants.Commands.DesactivarTenant
{
    public class DesactivarTenantHandler : IRequestHandler<DesactivarTenantCommand, bool>
    {
        private readonly ITenantRepository _repository;

        public DesactivarTenantHandler(ITenantRepository repositorio)
        {

             _repository = repositorio;
            
        }

        public async Task<bool> Handle(DesactivarTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = await _repository.GetByIdAsync(request.IdTenant, cancellationToken);

            if (tenant == null) 
            {
                throw new NotFoundException("Tenant", request.IdTenant); 
            }
            tenant.Desactivar();


            await _repository.UpdateAsync(tenant, cancellationToken);
            return true; 
        }
    }
}
