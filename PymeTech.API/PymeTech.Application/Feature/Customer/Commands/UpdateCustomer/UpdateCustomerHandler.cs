using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PymeTech.Application.Common.Exceptions;
using System.Linq.Expressions;
using PymeTech.Domain.Entities;

namespace PymeTech.Application.Feature.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;


        public UpdateCustomerHandler(ICurrentUserService currentUser , ICustomerRepository customerRepository, IUnitOfWork unitOfWork )
        {
            _currentUser = currentUser;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(_currentUser.IdTenant , request.IdCliente , cancellationToken );
            if (customer == null) 
            {
                throw new NotFoundException("Clientes " , request.IdCliente ); 
            }
            customer.Update(
      request.TipoDocumento,
      request.NumeroDocumento,
      request.RazonSocial,
      request.NombreContacto,
      request.Email,
      request.Telefono,
      request.Direccion,
      request.TipoCliente,
      _currentUser.IdUsuario
  );


            await _unitOfWork.SaveAsync(cancellationToken);

            return true; 






        }
    }
}
