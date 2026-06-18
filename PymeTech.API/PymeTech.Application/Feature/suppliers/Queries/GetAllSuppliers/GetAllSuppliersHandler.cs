using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.suppliers.SuppliersDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersHandler : IRequestHandler<GetAllSuppliersQuery, PagedResult<SupplerSummaryDTO>>
    {
        private readonly ISuppliersRepository _repository;
        private readonly ICurrentUserService _currentUser; 
       
        public GetAllSuppliersHandler(ICurrentUserService currentUser , ISuppliersRepository repository)
        {
            _currentUser = currentUser;
            _repository = repository; 
        }

        public async Task<PagedResult<SupplerSummaryDTO>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllPageedAsync(_currentUser.IdTenant, request.PageNumber, request.PageSize, cancellationToken); 
        }
    }
}
