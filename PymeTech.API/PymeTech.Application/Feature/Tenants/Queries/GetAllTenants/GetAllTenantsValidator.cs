using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Queries.GetAllTenants
{
    public class GetAllTenantsValidator : AbstractValidator<GetAllTenantsQuery>
    {


        public GetAllTenantsValidator()
        {
            // No se requieren reglas de validación específicas para esta consulta, pero se pueden agregar si es necesario.
        }
    }
}
