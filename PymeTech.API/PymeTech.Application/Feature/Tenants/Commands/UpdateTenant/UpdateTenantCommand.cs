using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Commands.UpdateTenant
{
    public record  UpdateTenantCommand: IRequest<bool>
    {
        public  int IdTenant { get; init;  }
        public string Nombre { get; init; } 
        public string Email { get; init; } 
        public string Telefono { get; init; } 

    }
}
