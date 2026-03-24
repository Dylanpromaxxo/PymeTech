using MediatR;
using PymeTech.Application.Feature.Tenants.TenantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Queries.GetTenantsById
{
    public record GetTenantByIDQuery : IRequest<TenantDTO>
    {
        public int IdTenant { get; init; } 
    }
}
