using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersValidator :AbstractValidator<GetAllSuppliersQuery>
    {
        public GetAllSuppliersValidator()
        {
            RuleFor(x => x.PageNumber)
               .GreaterThan(0)
               .WithMessage("El numero de pagina debe ser mayor a 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("El tamano de pagina debe ser mayor a 0.")
                .LessThanOrEqualTo(100)
                .WithMessage("El tamano de pagina no puede ser mayor a 100.");

           
        }
    }
}
