using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Commands.CreateRol
{
    public class CreateRolHandler : IRequestHandler<CreateRolCommand, int>
    {
        private readonly IRolesRepository _rolRepository;

        public CreateRolHandler(IRolesRepository rolRepository)
        {
             _rolRepository = rolRepository; 
        }

        public async Task<int> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            var rol = new Rol
                (
                    idTenant: request.IdTenant,
                    nombreRol: request.Nombre,
                    descripcion: request.Descripcion
                );

            return  await _rolRepository.AddAsync(rol, cancellationToken); 
           
        }
    }
}
