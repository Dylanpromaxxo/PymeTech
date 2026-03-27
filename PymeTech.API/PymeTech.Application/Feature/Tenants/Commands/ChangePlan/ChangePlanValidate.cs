using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Commands.ChangePlan
{
    public class ChangePlanValidate : AbstractValidator<ChangePlanTenantCommand>
    {
        public ChangePlanValidate()
        {
            RuleFor(p => p.IdTenant).GreaterThan(0).WithMessage("El id Tenant no puede ser menor a 0");
            RuleFor(p => p.PlanSuscripcion).MaximumLength(20).Must(plan => new[] { 
                "BASICO",
                "PROFESIONAL",
                "ENTERPRISE"

            }.Contains(plan)).WithMessage("Plan de suscripcion invalido  ");
        }

    }
}
