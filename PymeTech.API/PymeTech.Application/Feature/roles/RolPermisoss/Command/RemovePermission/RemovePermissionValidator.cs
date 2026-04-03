using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.RolPermisoss.Command.RemovePermission
{
    public  class RemovePermissionValidator : AbstractValidator <RemovePermissionCommand> 
    {
        public RemovePermissionValidator()
        {
             RuleFor(p => p.IdTenant).GreaterThan(0).WithMessage("El id del tenant no puede ser menor a 0 "); 
            RuleFor(p => p.IdRol).GreaterThan(0).WithMessage("El id del rol no puede ser menor a 0 "); 
             RuleFor(p => p.IdPermisos).GreaterThan(0).WithMessage("El id del permiso no puede ser menor a 0 ");

        }
    }
}
