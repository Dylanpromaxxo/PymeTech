using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Exceptions; 
namespace PymeTech.Application.Feature.Customer.Commands.ChangeStatus
{
    public record ChangeStatusCustomerHandler : IRequestHandler<ChangeStatusCustomerCommand , bool>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUnitOfWork _unitOfWork; 
        private readonly ICustomerRepository _customerRepository;


        public ChangeStatusCustomerHandler(ICurrentUserService currentUser, IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _currentUser = currentUser;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(ChangeStatusCustomerCommand request, CancellationToken cancellationToken)
        {
            //validar que el cliente exista 
            var customer = await _customerRepository.GetByIdAsync(_currentUser.IdTenant , request.IdCliente , cancellationToken );
            if (customer == null) 
            {
                throw new NotFoundException("Cliente" , request.IdCliente );
               
            }
            customer.ChangeStatus(_currentUser.IdUsuario);
            await _unitOfWork.SaveAsync(cancellationToken);
            return true; 




        }
    }
}
