using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Commands.DesactivarTenant
{
    public record DesactivarTenantCommand : IRequest<bool>
    {
        public int IdTenant { get; init; } 
    }
}
