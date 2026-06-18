using MediatR;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Categories.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Queries.GetAll
{
    public class GetAllCategoriesQuery:IRequest<PagedResult<CategoriesDTO>>
    {
        public int PageSize { get; init; } 
        public int PageNumber { get; init; }
        public bool? Activo { get; init; } 
    }
}
