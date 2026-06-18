using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Store.Commands.Create
{
    public class CreateStoreHandler : IRequestHandler<CreateStoreCommand, int>
    {
        
        private ICurrentUserService _currentUser;
        private IUnitOfWork _unitOfWork;

        public CreateStoreHandler(IStroreRepository repository, ICurrentUserService currentUser , IUnitOfWork UnitofWork)
        {
            _repository = repository;
            _unitOfWork = UnitofWork;
            _currentUser = currentUser; 

        }


        public async Task<int> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var almacen =  new Almacenes(_currentUser.IdTenant, request.Nombre, request.Descripcion, request.EsPrincipal, _currentUser.IdUsuario);
            await _unitOfWork.SaveAsync(cancellationToken);
            return almacen.IdAlmacen;


        }
    }
}
