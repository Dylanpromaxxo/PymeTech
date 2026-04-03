using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.RolPermisoss.Command.RemovePermission
{
    public class RemovePermissionHandler : IRequestHandler<RemovePermissionCommand, bool>
    {
        private readonly IRolesRepository  _repository;

        public RemovePermissionHandler(IRolesRepository repository)
        {
            _repository = repository; 

        }
        public async Task<bool> Handle(RemovePermissionCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemovePermissionToRolAsync(request.IdTenant, request.IdRol, request.IdPermisos,cancellationToken );
            return true; 
        }
    }
}
