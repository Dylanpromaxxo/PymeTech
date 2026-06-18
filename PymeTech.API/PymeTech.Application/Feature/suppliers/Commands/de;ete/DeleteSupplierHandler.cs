using MediatR;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Commands.de_ete
{
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommad, bool>
    {
        private readonly ISuppliersRepository _repository; 
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public DeleteSupplierHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUser , ISuppliersRepository repository)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteSupplierCommad request, CancellationToken cancellationToken)
        {
            var supplier = await _repository.GetByIdAsync(_currentUser.IdTenant , request.idProveedor ,cancellationToken);
            if (supplier == null)
            {
                return false;
            }

            supplier.ChangeStatus(_currentUser.IdUsuario);
            await _unitOfWork.SaveAsync(cancellationToken);

            return true;
        }
    }
}
