using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.suppliers.SuppliersDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Queries.GetPagendSuppliers
{
    public class GetPaginedSupplierHandler : IRequestHandler<GetPaginedSupplierQuery, PagedResult<SupplerSummaryDTO>>
    {

        private readonly ISuppliersRepository _repositoy;
        private readonly ICurrentUserService _currentUser;
        private readonly IUnitOfWork _unitOfwork; 


        public GetPaginedSupplierHandler( ICurrentUserService currentUser, IUnitOfWork unitOfwork , ISuppliersRepository repository )
        {
            _currentUser = currentUser;
            _unitOfwork = unitOfwork;
            _repositoy = repository; 
        }



        public async Task<PagedResult<SupplerSummaryDTO>> Handle(GetPaginedSupplierQuery request, CancellationToken cancellationToken)
        {
            return await _repositoy.GetPagedAsync(_currentUser.IdTenant, request.PageNumber, request.PageSize, request.Search, request.Activo, cancellationToken);

           



        }
    }
}
