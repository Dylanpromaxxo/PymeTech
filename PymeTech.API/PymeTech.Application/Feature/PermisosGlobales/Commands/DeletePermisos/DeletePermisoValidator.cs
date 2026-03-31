using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Commands.DeletePermisos
{
    public  class DeletePermisoValidator : AbstractValidator<DeletePermisoCommand >
    {
        public DeletePermisoValidator()
        {
            RuleFor(i => i.IdPermisos).GreaterThan(0).WithMessage("El id no puede ser menor a 0 "); 
            
        }
    }
}
