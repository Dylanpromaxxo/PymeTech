using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Queries.GetTenantsById
{
    public class GetTenantByIdValidator : AbstractValidator<GetTenantByIDQuery>
    {
        public GetTenantByIdValidator() { 
            RuleFor(t => t.IdTenant ).GreaterThan(0).WithMessage("El Id Debe ser mayor a 0 "); 
        
        }
    }
}
