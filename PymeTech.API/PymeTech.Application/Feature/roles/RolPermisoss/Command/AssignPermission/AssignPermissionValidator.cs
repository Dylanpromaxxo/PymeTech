using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.RolPermisoss.Command.AssignPermission
{
    public  class AssignPermissionValidator : AbstractValidator<AssignPermissionCommand> 
    {
        public AssignPermissionValidator()
        {
             RuleFor(t => t.IdTenant).GreaterThan(0).WithMessage("El Id del Tenant debe ser mayor que 0");
                RuleFor(t => t.IdRol).GreaterThan(0).WithMessage("El Id del Rol debe ser mayor que 0");
                RuleFor(t => t.IdPermisos).GreaterThan(0).WithMessage("El Id del Permiso debe ser mayor que 0");

            When(t => t.AsignadoPor != null, () =>
            {
                RuleFor(t => t.AsignadoPor).GreaterThan(0).WithMessage("El Id del Permiso debe ser mayor que 0");
            });
        }
    }
}
