using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.RolPermisoss.Command.AssignPermission
{
    public class AssignPermissionHandler : IRequestHandler<AssignPermissionCommand, bool>
    {
        private readonly IRolesRepository  _repository ;

        public AssignPermissionHandler(IRolesRepository repository)
        {
             
            _repository = repository;
        }

        public async Task<bool> Handle(AssignPermissionCommand request, CancellationToken cancellationToken)
        {
            var rolpermiso = new RolPermiso
                (
                    idTenant: request.IdTenant,
                    idRol : request.IdRol,
                    idPermiso: request.IdPermisos,
                    asignadoPor: request.AsignadoPor
                 
                );

            await _repository.AssignPermissionToRolAsync(rolpermiso, cancellationToken); 
            return true; 
        }
    }
}
