using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PymeTech.Application.Common.Exceptions;

namespace PymeTech.Application.Feature.Customer.Queries.GetByIdCustomer
{
    public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerQuery , CustomerDTO>
    {
        private readonly ICustomerRepository _repository;
        private readonly ICurrentUserService _currentUser;


        public GetByIdCustomerHandler(ICustomerRepository repository, ICurrentUserService currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public async Task<CustomerDTO> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(_currentUser.IdTenant, request.IdCliente, cancellationToken);

            if (customer == null) 
            {
                throw new NotFoundException("Customer", request.IdCliente); 
            }

            return new CustomerDTO
            {
                IdCliente = customer.IdCliente,
                TipoDocumento = customer.TipoDocumento,
                NumeroDoc = customer.NumeroDoc,
                RazonSocial = customer.RazonSocial,
                NombreContacto = customer.NombreContacto,
                Email = customer.Email,
                Telefono = customer.Telefono,
                Direccion = customer.Direccion,
                Tipo = customer.Tipo,
                Activo = customer.Activo,
                FechaCreacion = customer.FechaCreacion
             };

        }
    }
}
