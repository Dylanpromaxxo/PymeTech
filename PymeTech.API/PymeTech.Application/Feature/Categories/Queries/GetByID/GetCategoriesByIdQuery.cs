using MediatR;
using PymeTech.Application.Feature.Categories.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Queries.GetByID
{
    public class GetCategoriesByIdQuery : IRequest<CategoriesDTO>
    {
        public int CategoriId { get; init;  }
    }
}
