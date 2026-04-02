using MediatR;
using PymeTech.Application.Feature.roles.rolesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Queries.GetRolesbyIdTenant 
{
    public record GetRolesByIdTenantCommand : IRequest<List<RolesDTO>>
    {
        public  int IdTenant { get; init;   }

    }
}
