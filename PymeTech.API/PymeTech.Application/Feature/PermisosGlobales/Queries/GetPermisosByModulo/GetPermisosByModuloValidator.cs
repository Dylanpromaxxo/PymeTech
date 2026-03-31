using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Queries.GetPermisosByModulo
{
    public class GetPermisosByModuloValidator: AbstractValidator<GetPermisosByModuloCommand>
    {
        public GetPermisosByModuloValidator()
        {
            RuleFor(c => c.Modulo).NotEmpty().WithMessage("El modulo no puede venir vacio ");

            When(p => p.Accion != null, () =>
            {
                RuleFor(p => p.Accion).NotEmpty().WithMessage("La accion no puede con espacios vacios "); 
            }); 

        }

    }
}
