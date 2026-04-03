using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.RolPermisoss.Command.RemovePermission
{
    public  class RemovePermissionCommand :IRequest<bool>
    {
        public int IdTenant { get; init; } 
        public int IdRol { get; init; } 
        public int IdPermisos { get; init; } 
       
    }
}
