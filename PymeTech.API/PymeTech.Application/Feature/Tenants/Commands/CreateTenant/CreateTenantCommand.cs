using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Commands.CreateTenant
{
    public record CreateTenantCommand : IRequest<int>
    {
        
        public string Nombre  { get; init; } 
        public string Email { get; init; } 
        public string Telefono { get; init; }    
    }
}
