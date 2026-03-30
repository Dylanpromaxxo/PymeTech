using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Queries.GetAllPermisos
{
    public class GetAllPermisosHandler : IRequestHandler<GetAllPermisosCommand, List<PermisosDTO>>
    {
        readonly IPermisosRepository _Repository;

        public GetAllPermisosHandler(IPermisosRepository Repository)
        {
            _Repository = Repository; 
        }

        public async Task<List<PermisosDTO>> Handle(GetAllPermisosCommand request, CancellationToken cancellationToken)
        {
            var Permisos = await _Repository.GetAllAsync(cancellationToken);

            return Permisos.Select(Permisos => new PermisosDTO
            {
                IdPermisos = Permisos.IdPermiso, 
                Modulo = Permisos.Modulo, 
                Accion = Permisos.Accion, 
                Descripcion = Permisos.Descripcion

            }).ToList();




        }
    }
}
