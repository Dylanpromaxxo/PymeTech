using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Queries.GetAll
{
    public class GetAllCategoriesValidator: AbstractValidator<GetAllCategoriesQuery>
    {
        public GetAllCategoriesValidator()
        {
            
        }
    }
}
