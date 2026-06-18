using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using PymeTech.Application.Common.Exceptions;



namespace PymeTech.Application.Feature.suppliers.Commands.Update
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand, bool>
    {
        private readonly ISuppliersRepository _supplierRepository; 
        private readonly ICurrentUserService _currentUser; 
        private readonly IUnitOfWork _unitOfWork; 


        public UpdateSupplierHandler(ISuppliersRepository supplierRepository, ICurrentUserService currentUser, IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _currentUser = currentUser;
            _unitOfWork = unitOfWork;
        }



        public async Task<bool> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(_currentUser.IdTenant, request.IdProveedor, cancellationToken);
            if (supplier == null) 
            {
                throw new NotFoundException("Suppliers", request.IdProveedor);
            }
            supplier.Actualizar(request.TipoDocumento, request.NumeroDocumento, request.RazonSocial, request.NombreContacto, request.Email, request.Telefono, request.Direccion, _currentUser.IdUsuario);
            await _unitOfWork.SaveAsync(cancellationToken);
            return true;
        }
    }
}
