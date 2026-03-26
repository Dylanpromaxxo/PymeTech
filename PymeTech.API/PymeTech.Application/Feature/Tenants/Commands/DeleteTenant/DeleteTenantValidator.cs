using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Commands.DeleteTenant
{
    public class DeleteTenantValidator : AbstractValidator<DeleteTenantCommand>
    {
        public DeleteTenantValidator() {
            RuleFor(t => t.IdTenant).GreaterThan(0).WithMessage("El Id debe ser mayor a uno ");
        
        }
    }
}
