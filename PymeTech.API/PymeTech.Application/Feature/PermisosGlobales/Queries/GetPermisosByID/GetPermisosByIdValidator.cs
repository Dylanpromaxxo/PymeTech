using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Queries.GetPermisosByID
{
    public class GetPermisosByIdValidator : AbstractValidator<GetPermisosByIDCommand>
    {
        public GetPermisosByIdValidator()
        {
            RuleFor(p => p.IdPermisos).GreaterThan(0).WithMessage("El id del permiso no puede ser meno a 1 ");
        }
    }
}
