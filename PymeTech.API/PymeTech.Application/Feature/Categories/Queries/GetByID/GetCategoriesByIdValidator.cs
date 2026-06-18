using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Queries.GetByID
{
    public  class GetCategoriesByIdValidator : AbstractValidator<GetCategoriesByIdQuery>
    {
        public GetCategoriesByIdValidator()
        {
            RuleFor(c => c.CategoriId).GreaterThan(0).WithMessage("El id debe ser mayor a 0"); 

        }
    }
}
