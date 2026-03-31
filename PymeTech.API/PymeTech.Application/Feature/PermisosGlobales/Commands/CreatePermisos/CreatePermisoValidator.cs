using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Commands.CreatePermisos
{
    public  class CreatePermisoValidator:AbstractValidator<CreatePermisosCommand>
    {
        public CreatePermisoValidator()
        {
            RuleFor(p => p.Modulo).NotEmpty().WithMessage("El Modulo no puede venir vacio ");
            RuleFor(p => p.Accion).NotEmpty().WithMessage("La accion no puede venir vacia ");

            When(p => p.Accion != null, () =>
            {

                RuleFor(p => p.Descripcion).NotEmpty().WithMessage("La descripcion no puede venir con espacios vacios ");

            });

        }
    }
}
