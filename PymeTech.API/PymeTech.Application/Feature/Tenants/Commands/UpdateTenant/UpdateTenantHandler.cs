using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Commands.UpdateTenant
{
    public class UpdateTenantHandler : IRequestHandler<UpdateTenantCommand, bool>
    {
           private readonly ITenantRepository _repositories;

        public UpdateTenantHandler(ITenantRepository repo )
        {
            _repositories = repo; 

        }



        public async Task<bool> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            var QueryTenant = await _repositories.GetByIdAsync(request.IdTenant, cancellationToken);
            if (QueryTenant == null) 
            {
                throw new Exception("Tenant = 0"); 
            }

            QueryTenant.ActualizarDatos(
                nombre: request.Nombre,
                email: request.Email,
                telefono: request.Telefono
                );

             await _repositories.UpdateAsync(QueryTenant, cancellationToken);
            return true;

        }
    }
}
