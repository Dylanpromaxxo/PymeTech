using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Commands.DeletePermisos
{
  public record  DeletePermisoCommand : IRequest<bool>
    {
        public int IdPermisos { get; init; } 
    }
}
