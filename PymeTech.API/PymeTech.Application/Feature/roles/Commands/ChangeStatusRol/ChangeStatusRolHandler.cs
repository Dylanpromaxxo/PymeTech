using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PymeTech.Application.Common.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace PymeTech.Application.Feature.roles.Commands.ChangeStatusRol
{
    public class ChangeStatusRolHandler : IRequestHandler<ChangeStatusRolCommand, bool>
    {
        private readonly IRolesRepository _repository;

        public ChangeStatusRolHandler(IRolesRepository repository)
        {
            _repository = repository;  

        }

        public async Task<bool> Handle(ChangeStatusRolCommand request, CancellationToken cancellationToken)
        {
            var rol = await _repository.GetByIdAsync(request.IdRol, cancellationToken);
            if (rol == null) 
            {
                throw new NotFoundException("rol", request.IdRol); 
            }
            rol.ChangeStatus();

            await _repository.UpdateAsync(rol, cancellationToken);
            return true; 
        }
    }
}
