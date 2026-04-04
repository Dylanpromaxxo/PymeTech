using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.roles.rolesDTOs;
using PymeTech.Application.Common.Exceptions; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Queries.GetRolWithPermission
{
    internal class GetRolWithPermissionHandler : IRequestHandler<GetRolWithPermissionCommand, RolesDetailsDTO>
    {
        private readonly IRolesRepository  _repository ;

        public GetRolWithPermissionHandler(IRolesRepository repository)
        {
            _repository = repository; 
        }


        public async Task<RolesDetailsDTO> Handle(GetRolWithPermissionCommand request, CancellationToken cancellationToken)
        {
            var rol = await _repository.GetRolesWithPermissionAsync(request.IdRol, request.IdTenant, cancellationToken);

            if (rol == null)
                throw new NotFoundException("Rol", request.IdRol);

            return new RolesDetailsDTO
            {
                IdRol = rol.IdRol,
                NombreRol = rol.NombreRol,
                Descripcion = rol.Descripcion,
                Activo = rol.Activo,

                Permisos = rol.RolPermisos.Select(rp => new PermissionSummaryDTO
                {
                    IdPermiso = rp.Permiso.IdPermiso , 
                    Modulo = rp.Permiso.Modulo , 
                    Accion = rp.Permiso.Accion 
                }).ToList()};

        }
    }
}
