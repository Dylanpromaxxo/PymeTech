using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Store.Queries.GetById
{
    public class GetStoreByIdValidator: AbstractValidator<GetStoreByIdQuery>
    {
       public GetStoreByIdValidator() 
        {
            RuleFor(x => x.IdStore).GreaterThan(0).WithMessage("El Id de la tienda debe ser mayor a 0");
        }
    }
}
