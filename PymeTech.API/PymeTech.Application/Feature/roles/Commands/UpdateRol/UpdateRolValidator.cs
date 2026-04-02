using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Commands.UpdateRol
{
    internal class UpdateRolValidator :AbstractValidator<UpdateRolCommand> 
    {
        public UpdateRolValidator()
        {
            RuleFor(x => x.IdRol)
                .GreaterThan(0).WithMessage("El Id del rol debe ser mayor que cero."); 

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del rol es requerido.")
                .MaximumLength(60).WithMessage("El nombre del rol no puede exceder los 100 caracteres."); 
            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción del rol es requerida.")
                .MaximumLength(200).WithMessage("La descripción del rol no puede exceder los 200 caracteres."); 
        }
    }
}
