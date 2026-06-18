using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Categories.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Queries.GetAll
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, PagedResult<CategoriesDTO>>
    {
        private readonly ICategoriesRepository _repository;
        private readonly ICurrentUserService _currentUser; 

        public GetAllCategoriesHandler(ICurrentUserService currentUser , ICategoriesRepository  categories)
        {
            _currentUser = currentUser;
            _repository = categories; 
        }



        public async Task<PagedResult<CategoriesDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPagend(_currentUser.IdTenant, request.PageSize, request.PageNumber, request.Activo , cancellationToken);
        }
    }
}
