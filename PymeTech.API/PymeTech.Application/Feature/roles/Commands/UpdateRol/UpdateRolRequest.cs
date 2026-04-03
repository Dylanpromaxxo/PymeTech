using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Commands.UpdateRol
{
    public  record  UpdateRolRequest
    {
        public string Nombre  { get; init; } = string.Empty;
        public string Descripcion { get; init; } = string.Empty; 
    }
}
