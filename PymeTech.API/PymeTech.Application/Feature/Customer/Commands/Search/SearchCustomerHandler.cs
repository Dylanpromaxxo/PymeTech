using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Commands.Search
{
    public class SearchCustomerHandler : IRequestHandler<SearchCustomerCommand, List<SummaryCustomerDTO>>
    {
        private readonly ICustomerRepository _repoCustomer;
        private readonly ICurrentUserService _currentUser;

        public SearchCustomerHandler(ICustomerRepository repoCustomer, ICurrentUserService currentUser)
        {
            _repoCustomer = repoCustomer;
            _currentUser = currentUser;
        }


        public async Task<List<SummaryCustomerDTO>> Handle(SearchCustomerCommand request, CancellationToken cancellationToken)
        {
            var customers = await _repoCustomer.SearchAsync(_currentUser.IdTenant, request.Filter, cancellationToken);

            return customers.Select(c => new SummaryCustomerDTO
            {
                idCliente = c.IdCliente,
                TipoDocumento = c.TipoDocumento , 
                NombreContacto = c.NombreContacto , 
                Email = c.Email , 
                Telefono = c.Telefono, 
                FechaCreacion = c.FechaCreacion , 
                Activo = c.Activo 
            }).ToList();

        }
    }
}
