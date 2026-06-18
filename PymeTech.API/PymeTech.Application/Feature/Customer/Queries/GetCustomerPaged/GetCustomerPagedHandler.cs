using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Queries.GetCustomerPaged
{
    public class GetCustomerPagedHandler : IRequestHandler<GetCustomerPagedQuery, PagedResult<SummaryCustomerDTO>>
    {
        private readonly ICustomerRepository _customerRepositoy; 
        private readonly ICurrentUserService _currentUser; 
        public GetCustomerPagedHandler(ICustomerRepository customerRepositoy, ICurrentUserService currentUser)
        {
            _customerRepositoy = customerRepositoy;
            _currentUser = currentUser;
        } 


        public async Task<PagedResult<SummaryCustomerDTO>> Handle(GetCustomerPagedQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepositoy.GetPagedAsync(_currentUser.IdTenant, request.PageNumber, request.PageSize, request.Seach, request.Activo, cancellationToken); 

        }
    }
}
