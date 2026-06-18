using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Queries.GetCustomerPaged
{
    public class GetCustomersPagedValidator : AbstractValidator<GetCustomerPagedQuery>
    {
        public GetCustomersPagedValidator()
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
