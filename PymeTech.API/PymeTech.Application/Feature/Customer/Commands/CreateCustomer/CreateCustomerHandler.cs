using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Commands.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentService;


        public CreateCustomerHandler(ICustomerRepository repository, IUnitOfWork unitOfWork, ICurrentUserService currentService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _currentService = currentService;
        }




        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Clientes(_currentService.IdTenant, request.TipoDocumento, request.NumeroDocumento, request.RazonSocial,
                request.NombreContacto, request.Email, request.Telefono, request.Direccion, request.TipoCliente, _currentService.IdUsuario);

            await _repository.AddAsync(customer, cancellationToken); 
            await _unitOfWork.SaveAsync(cancellationToken);
            return customer.IdCliente;
        }   
    }
}
