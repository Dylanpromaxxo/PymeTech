using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Commands.CreatePermisos
{
    public class CreatePermisosHandler : IRequestHandler<CreatePermisosCommand, int>
    {
        private readonly IPermisosRepository _repository;

        public CreatePermisosHandler(IPermisosRepository repository)
        {
             _repository = repository;
            
        }




        public async Task<int> Handle(CreatePermisosCommand request, CancellationToken cancellationToken)
        {
            var permisos = new Permisos(
                modulo: request.Modulo , 
                accion: request .Accion ,
                descripcion: request.Descripcion


                );

            var response = await _repository.AddAsync(permisos, cancellationToken);

            return response; 
        }
    }
}
