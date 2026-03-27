using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PymeTech.Application.Common.Exceptions;
using System.Diagnostics.CodeAnalysis;
namespace PymeTech.Application.Feature.Tenants.Commands.ChangePlan
{
    public class ChangePlanTenantHandler : IRequestHandler<ChangePlanTenantCommand, bool>
    {
        readonly ITenantRepository _repository;


        public ChangePlanTenantHandler(ITenantRepository repo )
        {
             _repository = repo; 
        }

        public async Task<bool> Handle(ChangePlanTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = await _repository.GetByIdAsync(request.IdTenant, cancellationToken);
            if (tenant == null) 
            {
                throw new NotFoundException("Tenant" , request.IdTenant );
            }

            tenant.ChangePlan(request.PlanSuscripcion);

            await _repository.UpdateAsync(tenant, cancellationToken);
            return true; 
            




        }
    }


}
