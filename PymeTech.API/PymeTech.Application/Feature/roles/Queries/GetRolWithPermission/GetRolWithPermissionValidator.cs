using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Queries.GetRolWithPermission
{
    public class GetRolWithPermissionValidator : AbstractValidator<GetRolWithPermissionCommand>
    {
        public GetRolWithPermissionValidator()
        {
            RuleFor(c => c.IdTenant).GreaterThan(0).WithMessage("El IdTenant no puede ser menor a 0 ");
            RuleFor(c => c.IdRol).GreaterThan(0).WithMessage("El IdRol no puede ser menor a 0");

        }
    }
}
