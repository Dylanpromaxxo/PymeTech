using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Queries.GetRolesbyIdTenant 
{
    public class GetRolesByIdTenantValidator: AbstractValidator<GetRolesByIdTenantCommand> 
    {
        public GetRolesByIdTenantValidator()
        {
            RuleFor (x => x.IdTenant)
                .GreaterThan(0).WithMessage("El Id del Tenant debe ser mayor que cero."); 
        }
    }
}
