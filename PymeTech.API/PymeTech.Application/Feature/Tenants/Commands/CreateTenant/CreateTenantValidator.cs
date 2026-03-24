using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Commands.CreateTenant
{
    public class CreateTenantValidator : AbstractValidator<CreateTenantCommand>
    {
        public CreateTenantValidator() 
        {
            RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio")
            .MaximumLength(100).WithMessage("El nombre no puede tener más de 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("El email no tiene un formato válido");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio")
                .MaximumLength(20).WithMessage("El teléfono no puede tener más de 20 caracteres");
        }
    }
}
