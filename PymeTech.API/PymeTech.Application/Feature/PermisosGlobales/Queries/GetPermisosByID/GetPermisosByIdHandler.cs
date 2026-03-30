using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using PymeTech.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Queries.GetPermisosByID
{
    public class GetPermisosByIdHandler : IRequestHandler<GetPermisosByIDCommand, PermisosDTO>
    {
        private readonly IPermisosRepository _repository;
        public GetPermisosByIdHandler(IPermisosRepository repository)
        {
            
            _repository  = repository; 
        }



        public async Task<PermisosDTO> Handle(GetPermisosByIDCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetByIdAsync(request.IdPermisos, cancellationToken); 

            if (response == null)
            {
                throw new NotFoundException("Permisos", request.IdPermisos); 
            }

            return new PermisosDTO { 
                IdPermisos = response.IdPermiso , 
                Modulo = response.Modulo , 
                Accion = response.Accion , 
                Descripcion = response.Descripcion 
            
            
            };



        }
    }
}
