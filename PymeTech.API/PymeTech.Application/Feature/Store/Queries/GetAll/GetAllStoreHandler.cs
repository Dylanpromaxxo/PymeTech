using MediatR;
using Microsoft.VisualBasic;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Store.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Store.Queries.GetAll
{
    public class GetAllStoreHandler : IRequestHandler<GetAllStoreQuery, PagedResult<StoreSummaryDTO>>
    {
        private readonly IStroreRepository _repository;
        private readonly ICurrentUserService _currentUser;

        public GetAllStoreHandler(IStroreRepository repository , ICurrentUserService user)
        {
            _repository = repository;
            _currentUser = user; 
            
        }


        public async Task<PagedResult<StoreSummaryDTO>> Handle(GetAllStoreQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(_currentUser.IdTenant, request.PageNumber, request.PageSize, request.Activo, cancellationToken); 

        }
    }
}
