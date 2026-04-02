using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PymeTech.Application.Common.Exceptions; 
using PymeTech.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PymeTech.Application.Feature.roles.Commands.UpdateRol
{
    public class UpdateRolHandler : IRequestHandler<UpdateRolCommand, bool>
    {
        private readonly IRolesRepository _repositoy;

        public UpdateRolHandler(IRolesRepository repositoy)
        {
             _repositoy = repositoy; 
        }


        public async Task<bool> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            var rol = await _repositoy.GetByIdAsync(request.IdRol , cancellationToken );
            
            if (rol == null)
            {
                throw new NotFoundException("rol", request.IdRol); 
            }
            rol.Update(request.Nombre, request.Descripcion); 

            await _repositoy.UpdateAsync(rol, cancellationToken);

            return true; 





        }
    }
}
