using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Commands.CreateRol
{
    public  class CreateRolValidator:AbstractValidator<CreateRolCommand> 
    {
        public CreateRolValidator()
        {
             RuleFor(x => x.IdTenant)
                .GreaterThan(0).WithMessage("El Id del Tenant debe ser mayor que cero."); 

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del rol es requerido.")
                .MaximumLength(60).WithMessage("El nombre del rol no puede exceder los 100 caracteres."); 

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción del rol es requerida.") 
                .MaximumLength(200).WithMessage("La descripción del rol no puede exceder los 200 caracteres."); 
        }
    }
}
