using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Commands.UpdateTenant
{
    public class UpdateTenantValidator : AbstractValidator<UpdateTenantCommand>
    {
        public UpdateTenantValidator() 
        {
            RuleFor(x => x.IdTenant)
            .GreaterThan(0).WithMessage("El Id es inválido");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("El email no tiene formato válido");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio")
                .MaximumLength(20).WithMessage("Máximo 20 caracteres");


        } 
    }
}
