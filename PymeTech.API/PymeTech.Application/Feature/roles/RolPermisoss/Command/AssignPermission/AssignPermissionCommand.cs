using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.RolPermisoss.Command.AssignPermission
{
    public record  AssignPermissionCommand : IRequest<bool>
    {
          public int IdTenant { get; init;  }
          public int IdRol { get; init; }
          public int IdPermisos { get; init; } 
          public int ? AsignadoPor { get; init;  }
    }
}
