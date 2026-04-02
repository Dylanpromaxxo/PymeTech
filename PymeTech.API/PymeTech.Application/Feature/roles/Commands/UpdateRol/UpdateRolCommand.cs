using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Commands.UpdateRol
{
    public  class UpdateRolCommand : IRequest<bool>
    {
        public int IdRol { get; init; }      
        public string Nombre { get; init; } = string.Empty;
        public string Descripcion { get; init; } = string.Empty;
    }
}
