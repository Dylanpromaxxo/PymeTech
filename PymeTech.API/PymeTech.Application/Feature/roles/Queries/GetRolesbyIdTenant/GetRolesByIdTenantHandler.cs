using MediatR;
using Microsoft.VisualBasic;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.roles.rolesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Queries.GetRolesbyIdTenant 
{
    public class GetRolesByIdTenantHandler : IRequestHandler<GetRolesByIdTenantCommand, List<RolesDTO>>
    {
        private readonly IRolesRepository  _repository;


        public GetRolesByIdTenantHandler(IRolesRepository repository)
        {
             _repository = repository; 
        }

        public async Task<List<RolesDTO>> Handle(GetRolesByIdTenantCommand request, CancellationToken cancellationToken)
        {
            var roles = await _repository.GetRolbyIdTenantAsync(request.IdTenant ,cancellationToken );
            

            return roles.Select(r => new RolesDTO
            {
                IdRol = r.IdRol,
                IdTenant = r.IdTenant,
                Nombre = r.NombreRol,
                Descripcion = r.Descripcion,
                Estado = r.Activo,
                FechaCreacion = r.FechaCreacion
            }).ToList(); 
        }
    }
}
