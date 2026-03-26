using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PymeTech.Application.Feature.Tenants.Commands.CreateTenant
{
    public class CreateTenantHandler : IRequestHandler<CreateTenantCommand, int>
    {
        private readonly ITenantRepository _repositorio;

        public CreateTenantHandler(ITenantRepository repository)
        { 
            _repositorio = repository; 
        
        }


        public async Task<int> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = new Tenant(
                 nombre: request.Nombre,
                 email: request.Email,
                 telefono: request.Telefono
                );


           
            return await _repositorio.AddAsync(tenant, cancellationToken); 
        }
    }
}
