using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Commands.ChangeStatusTenan
{
    public class DesactivarTenantValidator : AbstractValidator<DesactivarTenantCommand>
    {
        public DesactivarTenantValidator()
        {
            RuleFor(c => c.IdTenant).GreaterThan(0).WithMessage("El tenant no puede ser menor a 0 "); 

        }

    }
}
