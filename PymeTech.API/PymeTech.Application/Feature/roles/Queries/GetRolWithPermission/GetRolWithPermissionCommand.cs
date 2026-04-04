using MediatR;
using PymeTech.Application.Feature.roles.rolesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Queries.GetRolWithPermission
{
    public class GetRolWithPermissionCommand : IRequest<RolesDetailsDTO>
    {
        public  int IdRol { get; init ; }
        public int IdTenant { get; init; }   

    }
}
