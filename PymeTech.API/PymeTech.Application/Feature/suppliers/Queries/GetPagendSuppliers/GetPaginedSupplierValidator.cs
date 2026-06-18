using FluentValidation;
using PymeTech.Application.Feature.Customer.Queries.GetCustomerPaged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Queries.GetPagendSuppliers
{
    public class GetPaginedSupplierValidator : AbstractValidator<GetCustomerPagedQuery>
    {
        public GetPaginedSupplierValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("El numero de pagina debe ser mayor a 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("El tamano de pagina debe ser mayor a 0.")
                .LessThanOrEqualTo(100)
                .WithMessage("El tamano de pagina no puede ser mayor a 100.");

            RuleFor(x => x.Seach)
                .MaximumLength(100)
                .WithMessage("La busqueda no puede superar los 100 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Seach));
        }

    }
}
