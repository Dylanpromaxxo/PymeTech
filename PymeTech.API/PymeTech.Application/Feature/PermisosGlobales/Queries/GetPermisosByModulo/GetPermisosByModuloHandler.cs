using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Queries.GetPermisosByModulo
{
    public class GetPermisosByModuloHandler: IRequestHandler<GetPermisosByModuloCommand , List<PermisosDTO>>
    {
        private readonly IPermisosRepository _repository;


        public GetPermisosByModuloHandler(IPermisosRepository repository)
        {
           _repository = repository; 
        }

        public async Task<List<PermisosDTO>> Handle(GetPermisosByModuloCommand request, CancellationToken cancellationToken)
        {
           var permisos = await  _repository.GetByModuloAsync(request.Modulo, request.Accion, cancellationToken);

            return  permisos.Select(permiso => new PermisosDTO { 
                IdPermisos = permiso.IdPermiso , 
                Modulo = permiso.Modulo , 
                Accion  = permiso.Accion , 
                Descripcion = permiso.Descripcion , 
            
            
            }).ToList();

        }
    }
}
