using MediatR;
using PymeTech.Application.Feature.Tenants.TenantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.Queries.GetTenantsDesctivados
{
    public class GetTenantDesactivadosQuery :IRequest<List<TenantDTO>>
    {
    }
}
