using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PymeTech.Application.Common.Exceptions;

namespace PymeTech.Application.Feature.Tenants.Commands.DeleteTenant
{
    public class DeleteTenantHandler : IRequestHandler<DeleteTenantCommand, bool>
    {
        private readonly ITenantRepository _repository;

        public DeleteTenantHandler(ITenantRepository repositorio)
        {
            _repository = repositorio; 
            
        }



        public async Task<bool> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = await _repository.GetByIdAsync(request.IdTenant, cancellationToken);
            if (tenant == null) 
            {
                throw new NotFoundException("Tenant", request.IdTenant); 

            }
            await _repository.DeleteAsync(tenant, cancellationToken); 
            return true;
        }
    }
}
