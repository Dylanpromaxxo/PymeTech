using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDTO>>
    {
        private readonly ICustomerRepository _repository;
        private readonly ICurrentUserService _currentUser;


        public GetAllCustomerHandler(ICustomerRepository repository, ICurrentUserService currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }



        public async Task<List<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllCustomer(_currentUser.IdTenant , cancellationToken);

            return customers.Select(c => new CustomerDTO
            {
                idCliente = c.IdCliente,
                TipoDocumento = c.TipoDocumento , 
                NumeroDocumento = c.NumeroDoc , 
                RazonSocial = c.RazonSocial , 
                NombreContacto = c.NombreContacto , 
                Email = c.Email, 
                Telefono = c.Telefono,
                Direccion = c.Direccion , 
                TipoCliente = c.Tipo , 
                Activo = c.Activo, 
                FechaCreacion = c.FechaCreacion 


            }).ToList();
            
        }
    }
}
