using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Customer.CustomerDTOs;


namespace PymeTech.Application.Feature.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomersQuery, List<SummaryCustomerDTO>>
    {
        private readonly ICustomerRepository _repository;
        private readonly ICurrentUserService _currentUser;


        public GetAllCustomerHandler(ICustomerRepository repository, ICurrentUserService currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }



        public async Task<List<SummaryCustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllCustomer(_currentUser.IdTenant , cancellationToken);

            return customers.Select(c => new SummaryCustomerDTO
            {
                idCliente = c.IdCliente,
                TipoDocumento = c.TipoDocumento , 
                NombreContacto = c.NombreContacto , 
                Email = c.Email, 
                Telefono = c.Telefono,
                Activo = c.Activo, 
                FechaCreacion = c.FechaCreacion 


            }).ToList();
            
        }
    }
}
