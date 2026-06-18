using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Commands.Create
{
    public class CreateSupplierHandler : IRequestHandler<CreateSuppliercommand, int>
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IUnitOfWork _unitOfWork; 

        public CreateSupplierHandler(ISuppliersRepository suppliersRepository, ICurrentUserService currentUser, IUnitOfWork unitOfWork  )
        {
            _suppliersRepository = suppliersRepository;
            _currentUser = currentUser;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateSuppliercommand request, CancellationToken cancellationToken)
        {
            var supplier = new Proveedores(_currentUser.IdTenant, request.TipoDocumento, request.NumeroDocumento, request.RazonSocial
                , request.NombreContacto, request.Email, request.Telefono, request.Direccion, _currentUser.IdUsuario, null);


            await _suppliersRepository.Create(supplier, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return supplier.IdProveedor;


        }
    }
}
