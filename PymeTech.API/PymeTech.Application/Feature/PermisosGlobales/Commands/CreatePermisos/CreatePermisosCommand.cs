using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Commands.CreatePermisos
{
    public record CreatePermisosCommand : IRequest<int>
    {
        public string Modulo { get; init; } = string.Empty;
        public string Accion { get; init; } = string.Empty; 
        public string ? Descripcion { get; init; } 
        

    }
}
