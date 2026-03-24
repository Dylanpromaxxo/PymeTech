using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PymeTech.Application.Feature.Tenants.TenantDTOs;

namespace PymeTech.Application.Feature.Tenants.Queries.GetAllTenants
{
    public record GetAllTenantsQuery : IRequest<List<TenantDTO>>
    {
         
    }
}
