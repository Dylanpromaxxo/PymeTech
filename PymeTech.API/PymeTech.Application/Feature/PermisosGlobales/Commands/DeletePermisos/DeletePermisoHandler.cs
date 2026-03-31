using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PymeTech.Application.Common.Exceptions;

namespace PymeTech.Application.Feature.PermisosGlobales.Commands.DeletePermisos
{
    public class DeletePermisoHandler : IRequestHandler<DeletePermisoCommand, bool>
    {
        private readonly IPermisosRepository _repository;

        public DeletePermisoHandler(IPermisosRepository repository)
        {
            _repository = repository; 
        }

        public async Task<bool> Handle(DeletePermisoCommand request, CancellationToken cancellationToken)
        {
            var permiso = await  _repository.GetByIdAsync(request.IdPermisos, cancellationToken);

            if (permiso == null) 
            {
                throw new NotFoundException("Permisos", request.IdPermisos);
            }
            await _repository.DeleteAsync(permiso, cancellationToken); 
            return true; 

        }
    }
}
