using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.rolesDTOs
{
    public   class RolesDTO
    {
        public  int IdRol { get; init; }
        public int IdTenant { get; init; }
        public string Nombre { get; init; } = string.Empty;
        public string  Descripcion { get; init; } = string.Empty;
        public bool Estado { get; init; }
        public DateTime  FechaCreacion { get; init; } 

    }
}
